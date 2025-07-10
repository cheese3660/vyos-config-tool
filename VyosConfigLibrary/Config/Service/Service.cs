using VyosConfigLibrary.Config.Service.DHCP;
using VyosConfigLibrary.Config.Service.HTTPS;
using VyosConfigLibrary.Config.Service.NTP;
using VyosConfigLibrary.Config.Service.SSH;

namespace VyosConfigLibrary.Config.Service;

public class Service : BaseVyosConfigNode<Service>
{
    // TODO: UDP Broadcast Policy
    // TODO: Config Sync
    // TODO: Conntrack Sync
    // TODO: Console Server
    // TODO: DHCP Relay
    public Dhcp? DhcpServer { get; set; }
    // TODO: DNS Forwarding
    // TODO: Dynamic DNS
    // TODO: Event Handler
    public Https? Https { get; set; }
    // TODO: IPoE Server
    // TODO: LLDP
    // TODO: mDNS Repeater
    // TODO: Monitoring
    public Ntp? Ntp { get; set; }
    // TODO: PPPoE
    // TODO: Router Advertisements
    // TODO: Salt-Minion
    // TODO: SNMP
    public Ssh? Ssh { get; set; }
    // TODO: TFTP Server
    // TODO: Webproxy
    // TODO: suricata
}