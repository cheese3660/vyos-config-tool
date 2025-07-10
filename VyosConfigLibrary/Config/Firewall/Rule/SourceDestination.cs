namespace VyosConfigLibrary.Config.Firewall.Rule;

public class SourceDestination : BaseVyosConfigNode<SourceDestination>
{
    public string? Address { get; set; }
    public string? AddressMask { get; set; }
    public string? Fqdn { get; set; }
    public Geoip? Geoip { get; set; }
    public string? MacAddress { get; set; }
    public string? Port { get; set; }
    public Group? Group { get; set; }
}