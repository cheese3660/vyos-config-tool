namespace VyosConfigLibrary.Config.Service.DHCP;

public class DnsServer : BaseVyosConfigNode<DnsServer>
{
    public string? Address { get; set; }
    public int? Port { get; set; }
}