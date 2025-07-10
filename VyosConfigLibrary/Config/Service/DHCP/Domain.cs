namespace VyosConfigLibrary.Config.Service.DHCP;

public class Domain : BaseVyosConfigNode<Domain>
{
    public string? KeyName { get; set; }
    public Dictionary<string, DnsServer>? DnsServer { get; set; }
}