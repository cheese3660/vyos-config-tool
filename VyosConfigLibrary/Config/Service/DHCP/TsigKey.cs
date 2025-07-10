namespace VyosConfigLibrary.Config.Service.DHCP;

public class TsigKey : BaseVyosConfigNode<TsigKey>
{
    public string? Algorithm { get; set; }
    public string? Secret { get; set; }
}