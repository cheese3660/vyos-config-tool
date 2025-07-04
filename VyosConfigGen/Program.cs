// See https://aka.ms/new-console-template for more information

using VyosConfigGen;
using YamlDotNet.Serialization;

var path = args[0];
var yaml = File.ReadAllText(path);
var configSource = VyosConfigSource.FromYaml(yaml);
var vyos = new ConfigBuilder();

// Now let's generate the wan interface
vyos.Edit("interfaces ethernet", configSource.WanInterface);
vyos.Delete("address");
vyos.Delete("description");
vyos.SetObject(new
{
    Description = "WAN",
    Address = configSource.Networks
        .Select(x => x.WanIp)
        .Prepend(configSource.WanLocalAddr)
        .ToArray()
});

Space();

// Now the lan configuration
vyos.Edit("interfaces ethernet", configSource.LanInterface);
vyos.Delete("vif");
foreach (var network in configSource.Networks)
{
    var vlanId = network.LanVlan;
    var readable = (new IpInterface(network.WanIp)).Ip;
    var description = $"{network.Name} | wan: {readable}";
    vyos.PushEdit("vif", vlanId);
    vyos.SetObject(new
    {
        Description = description,
        Address = network.LanIps.ToArray()
    });
    vyos.PopEdit();
}

Space();

// Now the wireguard configuration
vyos.Edit();
vyos.Delete("interfaces wireguard");
vyos.Edit("interfaces wireguard wg0");
vyos.SetObject(new
{
    PrivateKey = configSource.Wireguard.PrivateKey,
    Address = configSource.Wireguard.Address,
    Port = configSource.Wireguard.Port,
});

// vyos.Set("private-key", configSource.Wireguard.PrivateKey);
// vyos.Set("address", configSource.Wireguard.Address);
// vyos.Set("port", configSource.Wireguard.Port);
foreach (var peer in configSource.Wireguard.Peers)
{
    vyos.Edit("interfaces wireguard wg0 peer", peer.Name);
    vyos.SetObject(new
    {
        AllowedIps = $"{peer.Address}/32",
        PublicKey = peer.PublicKey,
        PresharedKey = peer.PresharedKey,
    });
}

Space();

// Generate firewall network groups
//
// Per user net:
//  {user}
//  {user}-snat
//  {user}-lan
//  {user}-wg
// All LANS
vyos.Edit();
vyos.Delete("firewall group network-group");
vyos.Delete("firewall group address-group");

vyos.Edit("firewall group network-group");
vyos.Set("all-lan description \"All LAN networks\"");
vyos.Set("all-snat description \"All SNAT source networks\"");
foreach (var network in configSource.Networks)
{
    var name = network.Name;
    var user = $"user-{name}";
    var userLan = $"{user}-lan";
    var userSnat = $"{user}-snat";
    var userWg = $"{user}-wg";
    
    vyos.Set(user, "description",$"{name} | Access control group".VyosEscape());
    vyos.Set(userLan, "description", $"{name} | LAN subnets".VyosEscape());
    vyos.Set(userSnat, "description", $"{name} | SNATed subnets".VyosEscape());
    vyos.Set(userWg, "description", $"{name} | WG peers with access".VyosEscape());
    
    // Setup inherited groups
    vyos.Set(user, "include", userLan);
    vyos.Set(user, "include", userWg);
    vyos.Set(userSnat, "include", userLan);
    vyos.Set("all-lan", "include", userLan);
    vyos.Set("all-snat", "include", userSnat);
    
    // Add lan subnets to lan group
    foreach (var addr in network.LanIps)
    {
        vyos.Set(userLan, "network", new IpInterface(addr).Network);
    }
}

foreach (var peer in configSource.Wireguard.Peers)
{
    if (peer.PublicFromNetwork != null)
    {
        vyos.Set($"user-{peer.PublicFromNetwork}-snat network {peer.Address}/32");
    }

    if (peer.AccessNetworks != null)
    {
        foreach (var network in peer.AccessNetworks)
        {
            vyos.Set($"user-{network}-wg network {peer.Address}/32");
        }
    }
}

Space();

// Setup nat rules
vyos.Edit();
vyos.Delete("nat");
var nextNatSourceIdx = 1;
foreach (var network in configSource.Networks)
{
    var wanIp = (new IpInterface(network.WanIp)).Ip;
    vyos.Edit("nat source rule", nextNatSourceIdx++);
    vyos.SetObject(new
    {
        Description = $"{network.Name} | Outgoing from {wanIp}",
        OutboundInterface = new
        {
            Name = configSource.WanInterface
        },
        Source = new
        {
            Group = new
            {
                NetworkGroup =  $"user-{network.Name}-snat"
            }
        },
        Destination = new
        {
            Address = "0.0.0.0/0"
        },
        Translation = new
        {
            Address = wanIp
        }
    });
}

vyos.Edit("nat", "destination", "rule", 1);
vyos.SetObject(new
{
    Description =  "exclude wireguard connections",
    Destination = new
    {
        Address = configSource.Wireguard.EndpointAddr,
        Port = configSource.Wireguard.Port,
    },
    Exclude = true,
    InboundInterface = new
    {
        Name = "eth0"
    },
    Protocol = "udp"
});

var nextNatDestdx = 2;
foreach (var network in configSource.Networks)
{
    var wanIp = (new IpInterface(network.WanIp)).Ip;
    if (network.PortForwards != null)
    {
        foreach (var portForward in network.PortForwards)
        {
            vyos.Edit("nat destination rule", nextNatDestdx++);
            var extPort = portForward.ExternalPort;
            var intPort = portForward.InternalPort;
            var size = portForward.Size - 1;
            var extPortEnd = extPort + size;
            var intPortEnd = intPort + size;
            var description =
                $"{network.Name} | {wanIp}:{extPort}-{extPortEnd} -> {portForward.ForwardTo}:{intPort}-{intPortEnd}";
            
            vyos.SetObject(new
            {
                Description = description,
                Destination = new
                {
                    Address = wanIp,
                    Port = $"{extPort}-{extPortEnd}"
                },
                Translation = new
                {
                    Address = portForward.ForwardTo,
                    Port = $"{intPort}-{intPortEnd}"
                },
                InboundInterface = new
                {
                    Name = configSource.WanInterface
                },
                Protocol = portForward.Protocol
            });
        }
    }
    // Generate rule for primary host mapping
    vyos.Edit("nat destination rule", nextNatDestdx++);
    vyos.SetObject(new
    {
        Description = $"{network.Name} | {wanIp} -> {network.LanPrimaryHost}",
        Destination = new
        {
            Address = wanIp,
        },
        Translation = new
        {
            Address = network.LanPrimaryHost
        },
        InboundInterface = new
        {
            Name = configSource.WanInterface
        }
    });
    
    // // Hairpin
    // foreach (var sourceNetwork in configSource.Networks)
    // {
    //     vyos.Edit("nat destination rule", nextNatDestdx++);
    //     vyos.SetObject(new
    //     {
    //         Description = $"{network.Name} | hairpin nat -> {sourceNetwork.Name}",
    //         Destination = new
    //         {
    //             Address = network.WanIp,
    //         },
    //         Translation = new
    //         {
    //             Address = network.LanPrimaryHost
    //         },
    //         InboundInterface = new
    //         {
    //             Name = $"{configSource.LanInterface}.{network.LanVlan}"
    //         }
    //     });
    // }
}

// Hairpin setup
// SNAT

foreach (var sourceNetwork in configSource.Networks)
{
    foreach (var destNetwork in configSource.Networks)
    {
        vyos.Edit("nat source rule", nextNatSourceIdx++);
        vyos.SetObject(new
        {
            Description = $"{sourceNetwork.Name} | {destNetwork.Name} -> hairpin nat",
            OutboundInterface = new
            {
                Name = $"{configSource.LanInterface}.{destNetwork.LanVlan}",
            },
            Source = new
            {
                Group = new
                {
                    NetworkGroup = $"user-{sourceNetwork.Name}-snat",
                }
            },
            Destination = new
            {
                Group = new
                {
                    NetworkGroup = $"user-{sourceNetwork.Name}-snat",
                }
            },
            Translation = new
            {
                Address = sourceNetwork.WanIp
            }
        });
    }
}

// DNAT
foreach (var sourceNetwork in configSource.Networks)
{
    foreach (var destNetwork in configSource.Networks)
    {
        if (destNetwork.PortForwards != null)
        {
            foreach (var portForward in destNetwork.PortForwards)
            {
                vyos.Edit("nat destination rule", nextNatDestdx++);
                var extPort = portForward.ExternalPort;
                var intPort = portForward.InternalPort;
                var size = portForward.Size - 1;
                var extPortEnd = extPort + size;
                var intPortEnd = intPort + size;
                var description =
                    $"{sourceNetwork.Name} | hairpin nat -> {destNetwork.Name} (port forward {extPort}-{extPortEnd}/{portForward.Protocol})";
            
                vyos.SetObject(new
                {
                    Description = description,
                    Destination = new
                    {
                        Address = sourceNetwork.WanIp,
                        Port = $"{extPort}-{extPortEnd}"
                    },
                    Translation = new
                    {
                        Address = portForward.ForwardTo,
                        Port = $"{intPort}-{intPortEnd}"
                    },
                    InboundInterface = new
                    {
                        Name = $"{configSource.LanInterface}.{sourceNetwork.LanVlan}"
                    },
                    Protocol = portForward.Protocol
                });
            }
        }

        vyos.Edit("nat destination rule", nextNatDestdx++);
        vyos.SetObject(new
        {
            Description = $"{sourceNetwork.Name} | hairpin nat -> {destNetwork.Name} (1:1 nat catch-all)",
            Destination = new
            {
                Address = sourceNetwork.WanIp,
            },
            InboundInterface = new
            {
                Name = $"{configSource.LanInterface}.{sourceNetwork.LanVlan}"
            },
            Translation = new
            {
                Address = destNetwork.LanPrimaryHost
            }
        });
    }
}

Space();

// Dhcp setup
vyos.Edit();
vyos.Delete("service", "dhcp-server");
foreach (var network in configSource.Networks)
{
    var description = $"{network.Name} | {network.LanIps[0]}";
    var dhcpNetwork = new IpInterface(network.LanIps[0]).Network;
    var dhcpStart = dhcpNetwork[200];
    var dhcpEnd = dhcpNetwork[250];
    var routerIp = new IpInterface(network.LanIps[0]).Ip;
    vyos.Edit("service dhcp-server");
    vyos.Set("listen-interface", $"{configSource.LanInterface}.{network.LanVlan}");
    vyos.PushEdit("shared-network-name", $"user-{network.Name}");
    // vyos.Set("description", description);
    // vyos.Set("authoritative");
    // vyos.Set("ping-check");
    vyos.SetObject(new
    {
        Description = description,
        Authoritative = true,
        PingCheck = true
    });
    vyos.PushEdit("subnet", dhcpNetwork);
    vyos.Set("range", $"{network.Name}-primary start", dhcpStart);
    vyos.Set("range", $"{network.Name}-primary stop", dhcpEnd);
    vyos.Set("subnet-id", network.LanVlan);
    vyos.Set("option", "default-router", routerIp);
    if (network.DhcpLeases != null)
    {
        foreach (var mapping in network.DhcpLeases)
        {
            vyos.PushEdit("static-mapping", mapping.Hostname);
            vyos.SetObject(new
            {
                Description = $"{network.Name} | {mapping.Address}",
                IpAddress = mapping.Address,
                Mac = mapping.Mac
            });
            vyos.PopEdit();
        }
    }
}

Space();

// TODO: DNS Server?

// Firewall stuff
vyos.Edit("firewall");

vyos.Delete("ipv4");
vyos.Delete("zone");
vyos.Set("zone WAN member interface", configSource.WanInterface);
vyos.Set("zone LOCAL local-zone");

// Traffic to/from the router and wan
vyos.Edit("firewall");
vyos.Set("zone WAN from LOCAL firewall name LOCAL-WAN");
vyos.Set("zone LOCAL from WAN firewall name WAN-LOCAL");
vyos.PushEdit("ipv4 name");
vyos.Set("LOCAL-WAN default-action accept");
vyos.PushEdit("WAN-LOCAL");
vyos.Set("default-action drop");
vyos.PushEdit("rule 1");
vyos.SetObject(new
{
    Action = "accept",
    Destination = new
    {
        Address = configSource.Wireguard.EndpointAddr,
        Port = 51820
    },
    Protocol = "udp"
});
vyos.PopEdit();
vyos.PushEdit("rule 2");
vyos.SetObject(new
{
    Description = "allow related/established",
    Action = "accept",
    State = new
    {
        Related = true,
        Established = true
    }
});

// FW zones for vanguard
vyos.Edit("firewall");
vyos.PushEdit("zone");
vyos.Set("WIREGUARD member interface wg0");
vyos.Set("LOCAL from WIREGUARD firewall name WIREGUARD-LOCAL");
vyos.Set("WIREGUARD from LOCAL firewall name LOCAL-WIREGUARD");
vyos.Set("WAN from WIREGUARD firewall name WIREGUARD-WAN");
vyos.Set("WIREGUARD from WAN firewall name WAN-WIREGUARD");
vyos.PopEdit();
vyos.PushEdit("ipv4 name");
vyos.Set("LOCAL-WIREGUARD default-action accept");
vyos.Set("WIREGUARD-LOCAL default-action accept");
vyos.PushEdit("WAN-WIREGUARD rule 1");
vyos.SetObject(new
{
    Description = "allow related/established",
    State = new
    {
        Related = true,
        Established = true,
    },
    Action = "accept"
});
vyos.PopEdit();
vyos.PushEdit("WIREGUARD-WAN rule 1");
vyos.SetObject( new {
    Description = "allow SNATed connections",
    Source = new {
        Group = new
        {
            NetworkGroup = "all-snat"
        }
    },
    Action = "accept"
});

foreach (var network in configSource.Networks)
{
    var name = network.Name;
    var zone = $"USER_{name}";
    var zoneToWan = $"{zone}-WAN";
    var wanToZone = $"WAN-{zone}";
    var zoneToWireGuard = $"{zone}-WIREGUARD";
    var wireGuardToZone = $"WIREGUARD-{zone}";

    vyos.Edit("firewall");
    vyos.Set($"zone {zone} member interface {configSource.LanInterface}.{network.LanVlan}");
    vyos.Set($"zone WAN from {zone} firewall name {zoneToWan}");
    vyos.Set($"zone {zone} from WAN firewall name {wanToZone}");

    vyos.PushEdit("ipv4 name");
    vyos.PushEdit(zoneToWan);
    vyos.SetObject(new
    {
        Description = $"{name} | allow all connections to internet",
        DefaultAction = "accept",
    });
    vyos.PopEdit();
    vyos.PushEdit(wanToZone);
    vyos.Set("description", $"{name} | internet to local".VyosEscape());
    vyos.PushEdit("rule 1");
    vyos.SetObject(new
    {
        Description = "allow related/established",
        State = new
        {
            Related = true,
            Established = true,
        },
        Action = "accept"
    });
    vyos.PopEdit();
    vyos.PushEdit("rule 2");
    vyos.SetObject(new
    {
        Description = "allow DNATed connections",
        ConnectionStatus = new
        {
            Nat = "destination"
        },
        Action = "accept"
    });
    
    vyos.Edit("firewall");
    vyos.Set($"zone {zone} from WIREGUARD firewall name {wireGuardToZone}");
    vyos.Set($"zone WIREGUARD from {zone} firewall name {zoneToWireGuard}");
    
    vyos.PushEdit("ipv4 name");
    vyos.PushEdit(wireGuardToZone);
    vyos.Set("default-action drop");
    vyos.PushEdit("rule 1");
    vyos.SetObject(new
    {
        Source = new
        {
            Group = new
            {
                NetworkGroup = $"user-{name}-wg"
            }
        },
        Action = "accept"
    });
    vyos.PopEdit();
    vyos.PopEdit();
    vyos.PushEdit(zoneToWireGuard);
    vyos.Set("default-action drop");
    vyos.PushEdit("rule 1");
    vyos.SetObject(new
    {
        State = new
        {
            Related = true,
            Established = true,
        },
        Action = "accept"
    });

    foreach (var source in configSource.Networks.Where(x => x != network))
    {
        var sourceName = source.Name;
        var sourceZone = $"USER_{sourceName}";
        var sourceToDest = $"{sourceZone}-{zone}";
        vyos.Edit("firewall");
        vyos.Set($"zone {zone} from {sourceZone} firewall name {sourceToDest}");
        vyos.PushEdit($"ipv4 name {sourceToDest} rule 1");
        vyos.SetObject(new
        {
            State = new
            {
                Related = true,
                Established = true,
            },
            ConnectionStatus = new
            {
                Nat = "destination"
            },
            Action = "accept",
            Description = "allow related/established"
        });
    }

    if (network.AllowFrom != null)
    {
        foreach (var source in network.AllowFrom)
        {
            var sourceName = source.NetworkName;
            var sourceZone = $"USER_{sourceName}";
            var sourceToDest = $"{sourceZone}-{zone}";
            vyos.Edit("firewall");
            if (source.ToHosts != null)
            {
                var addrGroupName = $"{sourceName}-to-{name}-allowed-dests";
                vyos.PushEdit($"group address-group {addrGroupName}");
                vyos.SetObject(new
                {
                    Description = $"{name} | hosts that network {sourceName} is allowed to connect to",
                    Address = source.ToHosts.ToArray(),
                });
                vyos.PopEdit();

                vyos.PushEdit($"ipv4 name {sourceToDest} rule 2");
                vyos.SetObject(new
                {
                    Destination = new
                    {
                        Group = new
                        {
                            AddressGroup = addrGroupName,
                        }
                    },
                    Action = "accept",
                    Description = $"allow connections to addr group {addrGroupName}"
                });
            }
            else
            {
                vyos.Set($"ipv4 name {sourceToDest} default-action accept");
            }
        }
    }
}

return;

void Space()
{
    Console.WriteLine();
}