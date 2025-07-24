// See https://aka.ms/new-console-template for more information

using System.Net;
using VyosConfigGen;
using YamlDotNet.Serialization;

var path = args[0];
var yaml = File.ReadAllText(path);
var configSource = VyosConfigSource.FromYaml(yaml);
var vyos = new ConfigBuilder();
// First lets generate the VRF
vyos.Delete("vrf name wan");
vyos.Edit("vrf name wan");
vyos.Set("table 100");
var wanLocalAddr = new IpInterface(configSource.WanLocalAddr);
var wanNetwork = new IpInterface(configSource.WanLocalAddr).Network[1];
vyos.Set($"protocols static route 0.0.0.0/0 next-hop {wanNetwork}");
Space();

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
        .ToArray(),
    Vrf = "wan"
});

Space();

// And the virtual ethernets
vyos.Edit("interfaces virtual-ethernet veth0");
vyos.Delete();
vyos.SetObject(new
{
    Address = configSource.VethLocalNet,
    PeerName = "veth1",
    Vrf = "wan"
});

Space();
vyos.Edit("interfaces virtual-ethernet veth1");
vyos.Delete();
vyos.SetObject(new
{
    Address = configSource.Networks.Select(x =>
            new IpInterface(configSource.VethLocalNet).Network[new IpInterface(x.WanIp).Ip.Address & 0xff] + "/24")
        .ToArray(),
    PeerName = "veth0",
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
vyos.Delete("firewall");

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

    vyos.Set(user, "description", $"{name} | Access control group".VyosEscape());
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
    vyos.Edit("nat source rule", nextNatSourceIdx++ * 10);
    var vrfAddress =
        new IpInterface(configSource.VethLocalNet).Network[(new IpInterface(network.WanIp).Ip.Address & 0xFF)];
    foreach (var lanIp in network.LanIps)
    {
        vyos.SetObject(new
        {
            Description = $"{network.Name} | NAT {lanIp} into WAN VRF",
            OutboundInterface = new
            {
                Name = "veth1"
            },
            Source = new
            {
                Address = new IpInterface(lanIp).Network.ToString()
            },
            Translation = new
            {
                Address = vrfAddress
            }
        });
    }

    vyos.Edit("nat source rule", nextNatSourceIdx++ * 10);
    vyos.SetObject(new
    {
        Description = $"{network.Name} | NAT from WAN VRF to physical WAN",
        OutboundInterface = new
        {
            Name = "eth0"
        },
        Source = new
        {
            Address = vrfAddress
        },
        Translation = new
        {
            Address = wanIp
        }
    });
    vyos.Edit("nat source rule", nextNatSourceIdx++ * 10);
    vyos.SetObject(new
    {
        Description = $"{network.Name} | Set source addr for hairpinned connectionss",
        OutboundInterface = new
        {
            Name = "veth0"
        },
        Source = new
        {
            Address = vrfAddress
        },
        Translation = new
        {
            Address = wanIp
        }
    });
}

// vyos.Edit("nat source rule", nextNatSourceIdx++ * 10);
// vyos.SetObject(new
// {
//     Description = $"Router | outbound -> public",
//     OutboundInterface = new
//     {
//         Name = configSource.WanInterface
//     },
//     Source = new
//     {
//         Address = new IpInterface(configSource.WanLocalAddr).Ip,
//     },
//     Translation = new
//     {
//         Address = configSource.OutboundWanIp
//     }
// });

vyos.Edit("nat", "destination", "rule", 10);
vyos.SetObject(new
{
    Description = "exclude wireguard connections",
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
    var vrfAddress =
        new IpInterface(configSource.VethLocalNet).Network[(new IpInterface(network.WanIp).Ip.Address & 0xFF)];
    var wanIp = (new IpInterface(network.WanIp)).Ip;
    if (network.PortForwards != null)
    {
        foreach (var portForward in network.PortForwards)
        {
            vyos.Edit("nat destination rule", nextNatDestdx++ * 10);
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
                    Address = vrfAddress,
                    Port = $"{extPort}-{extPortEnd}"
                },
                Translation = new
                {
                    Address = portForward.ForwardTo,
                    Port = $"{intPort}-{intPortEnd}"
                },
                InboundInterface = new
                {
                    Name = "veth1"
                },
                Protocol = portForward.Protocol
            });
        }
    }

    vyos.Edit("nat destination rule", nextNatDestdx++ * 10);
    vyos.SetObject(new
    {
        Description = $"{network.Name} | wan -> vrf",
        Destination = new
        {
            Address = wanIp
        },
        InboundInterface = new
        {
            Name = "eth0"
        },
        Translation = new
        {
            Address = vrfAddress
        }
    });
    vyos.Edit("nat destination rule", nextNatDestdx++ * 10);
    vyos.SetObject(new
    {
        Description = $"{network.Name} | vrf -> primary host",
        Destination = new
        {
            Address = vrfAddress
        },
        InboundInterface = new
        {
            Name = "veth1"
        },
        Translation = new
        {
            Address = network.LanPrimaryHost
        }
    });
    vyos.Edit("nat destination rule", nextNatDestdx++ * 10);
    vyos.SetObject(new
    {
        Description = $"{network.Name} | vrf wan -> vrf",
        Destination = new
        {
            Address = wanIp
        },
        InboundInterface = new
        {
            Name = "veth0"
        },
        Translation = new
        {
            Address = vrfAddress
        }
    });
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


vyos.Edit();
var nextForwardRule = 1;
// Deny all from the forward filter
vyos.Comment("Deny all from the forward filter");
vyos.Set("firewall ipv4 forward filter default-action drop");
vyos.Edit("firewall ipv4 forward filter rule", nextForwardRule++ * 10);
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

vyos.Edit("firewall ipv4 forward filter rule", nextForwardRule++ * 10);
vyos.SetObject(new
{
    Description = "Allow VRF -> WAN",
    Action = "accept",
    Source = new
    {
        Address = new IpInterface(configSource.VethLocalNet).Network.NetworkAddress + "/24", 
    },
    Destination = new
    {
        Address = "0.0.0.0/0"
    }
});

vyos.Edit("firewall ipv4 forward filter rule", nextForwardRule++ * 10);
vyos.SetObject(new
{
    Action = "accept",
    Destination = new
    {
        Address = configSource.Wireguard.EndpointAddr,
        Port = 51820
    },
    Protocol = "udp",
});

vyos.Edit("firewall ipv4 forward filter rule", nextForwardRule++ * 10);
vyos.SetObject(new
{
    Description = "Jump connections to wireguard into their own ruleset",
    Source = new
    {
        Address = new IpInterface(configSource.Wireguard.Address).Network.ToString(),
    },
    Action = "jump",
    JumpTarget = "WIREGUARD-WAN",
});

vyos.Edit("firewall ipv4 name WIREGUARD-WAN rule 1");
vyos.SetObject(new
{
    Description = "allow SNATed connections",
    Source = new
    {
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
    var lanNetwork = $"user-{name}-lan";
    var zone = $"USER_{name}";
    var zoneToWan = $"{zone}-WAN";
    var zoneToWireGuard = $"{zone}-WIREGUARD";
    var wireguardToZone = $"WIREGUARD-{zone}";
    
    // Then zone to wireguard
    vyos.Edit("firewall ipv4 forward filter rule", nextForwardRule++ * 10);
    vyos.SetObject(new
    {
        Description = $"Zone policy for {zoneToWireGuard}",
        Source = new
        {
            Group = new
            {
                NetworkGroup = lanNetwork,
            }
        },
        Destination = new
        {
            Address = new IpInterface(configSource.Wireguard.Address).Network.ToString(),
        },
        Action = "jump",
        JumpTarget = zoneToWireGuard,
    });

    vyos.Edit($"firewall ipv4 name {zoneToWireGuard}");
    vyos.Set("default-action drop");
    
    vyos.Edit("firewall ipv4 forward filter rule", nextForwardRule++ * 10);
    vyos.SetObject(new
    {
        Description = $"Zone policy for {wireguardToZone}",
        Destination = new
        {
            Group = new
            {
                NetworkGroup = lanNetwork,
            }
        },
        Source = new
        {
            Address = new IpInterface(configSource.Wireguard.Address).Network.ToString(),
        },
        Action = "jump",
        JumpTarget = wireguardToZone,
    });

    vyos.Edit($"firewall ipv4 name {wireguardToZone}");
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

    if (network.AllowFrom != null)
    {
        foreach (var source in network.AllowFrom)
        {
            var sourceName = source.NetworkName;
            var sourceZone = $"USER_{sourceName}";
            var sourceToDest = $"{sourceZone}-{zone}";
            vyos.Edit("firewall ipv4 forward filter rule", nextForwardRule++ * 10);
            vyos.SetObject(new
            {
                Description = $"Zone policy for {sourceToDest}",
                Destination = new
                {
                    Group = new
                    {
                        NetworkGroup = lanNetwork,
                    }
                },
                Source = new
                {
                    Group = new
                    {
                        NetworkGroup = $"user-{sourceName}-lan"
                    }
                },
                Action = "jump",
                JumpTarget = sourceToDest,
            });

            
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

                vyos.PushEdit($"ipv4 name {sourceToDest} rule 1");
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

foreach (var network in configSource.Networks)
{
    
    var name = network.Name;
    var lanNetwork = $"user-{name}-lan";
    var zone = $"USER_{name}";
    var zoneToWan = $"{zone}-WAN";
    var wanToZone = $"WAN-{zone}";
    var zoneToWireGuard = $"{zone}-WIREGUARD";
    var wireguardToZone = $"WIREGUARD-{zone}";
    // Do the lan -> wan as late as possible as well
    vyos.Edit("firewall ipv4 forward filter rule", nextForwardRule++ * 10);
    vyos.SetObject(new
    {
        Description = $"Zone policy for {zoneToWan}",
        Source = new
        {
            Group = new
            {
                NetworkGroup = lanNetwork,
            }
        },
        Destination = new
        {
            Address = "0.0.0.0/0"
        },
        Action = "jump",
        JumpTarget = zoneToWan,
    });
    vyos.Edit($"firewall ipv4 name {zoneToWan}");
    vyos.SetObject(new
    {
        Description = $"{name} | allow all connections to internet",
        DefaultAction = "accept",
    });
    // Do the wan to lan as late as possible
    vyos.Edit("firewall ipv4 forward filter rule", nextForwardRule++ * 10);
    vyos.SetObject(new
    {
        Description = $"Zone policy for {wanToZone}",
        Destination = new
        {
            Group = new
            {
                NetworkGroup = lanNetwork,
            }
        },
        Source = new
        {
            Address = "0.0.0.0/0"
        },
        Action = "jump",
        JumpTarget = wanToZone,
    });
    
    vyos.Edit($"firewall ipv4 name {wanToZone}");
    vyos.Set("description", $"{name} | internet to local".VyosEscape());
    vyos.PushEdit("rule 1");
    vyos.SetObject(new
    {
        Description = "allow DNATed connections",
        ConnectionStatus = new
        {
            Nat = "destination"
        },
        Action = "accept",
    });
}

//
// foreach (var network in configSource.Networks)
// {
//
//     // foreach (var source in configSource.Networks.Where(x => x != network))
//     // {
//     //     var sourceName = source.Name;
//     //     var sourceZone = $"USER_{sourceName}";
//     //     var sourceToDest = $"{sourceZone}-{zone}";
//     //     vyos.Edit("firewall");
//     //     vyos.Set($"zone {zone} from {sourceZone} firewall name {sourceToDest}");
//     //     vyos.PushEdit($"ipv4 name {sourceToDest}");
//     //     vyos.PushEdit("rule 1");
//     //     vyos.SetObject(new
//     //     {
//     //         State = new
//     //         {
//     //             Related = true,
//     //             Established = true,
//     //         },
//     //         Action = "accept",
//     //         Description = "allow related/established"
//     //     });
//     //     vyos.PopEdit();
//     //     vyos.PushEdit("rule 2");
//     //     vyos.SetObject(new
//     //     {
//     //         ConnectionStatus = new
//     //         {
//     //             Nat = "destination"
//     //         },
//     //         Action = "accept",
//     //         Description = "allow DNATed connections"
//     //     });
//     // }
//     //
//     // if (network.AllowFrom != null)
//     // {
//     //     foreach (var source in network.AllowFrom)
//     //     {
//     //         var sourceName = source.NetworkName;
//     //         var sourceZone = $"USER_{sourceName}";
//     //         var sourceToDest = $"{sourceZone}-{zone}";
//     //         vyos.Edit("firewall");
//     //         if (source.ToHosts != null)
//     //         {
//     //             var addrGroupName = $"{sourceName}-to-{name}-allowed-dests";
//     //             vyos.PushEdit($"group address-group {addrGroupName}");
//     //             vyos.SetObject(new
//     //             {
//     //                 Description = $"{name} | hosts that network {sourceName} is allowed to connect to",
//     //                 Address = source.ToHosts.ToArray(),
//     //             });
//     //             vyos.PopEdit();
//     //
//     //             vyos.PushEdit($"ipv4 name {sourceToDest} rule 3");
//     //             vyos.SetObject(new
//     //             {
//     //                 Destination = new
//     //                 {
//     //                     Group = new
//     //                     {
//     //                         AddressGroup = addrGroupName,
//     //                     }
//     //                 },
//     //                 Action = "accept",
//     //                 Description = $"allow connections to addr group {addrGroupName}"
//     //             });
//     //         }
//     //         else
//     //         {
//     //             vyos.Set($"ipv4 name {sourceToDest} default-action accept");
//     //         }
//     //     }
//     // }
// }

return;

void Space()
{
    Console.WriteLine();
}