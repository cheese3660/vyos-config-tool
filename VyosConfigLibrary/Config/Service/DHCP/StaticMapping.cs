namespace VyosConfigLibrary.Config.Service.DHCP;

public class StaticMapping : BaseVyosConfigNode<StaticMapping>
{
    public string? Mac { get; set; }
    public string? Duid { get; set; }
    public string? IpAddress { get; set; }
}