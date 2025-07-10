using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Service.HTTPS;

public class Https : BaseVyosConfigNode<Https>
{
    public AllowClient? AllowClient { get; set; }
    public string? ListenAddress { get; set; }
    public int? Port { get; set; }
    public ConfigFlag? EnableHttpRedirect { get; set; }
    public string? TlsVersion { get; set; }
    public string? Vrf { get; set; }
    public uint? RequestBodySizeLimit { get; set; }
    public Api? Api { get; set; }
}