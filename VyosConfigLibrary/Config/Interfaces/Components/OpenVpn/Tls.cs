using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn;

public class Tls : BaseVyosConfigNode<Tls>
{
    public string? AuthKey { get; set; }
    public string? CaCertificate { get; set; }
    public string? Certificate { get; set; }
    public ConfigFlag? CryptKey { get; set; }
    public ConfigFlag? DhParams { get; set; }
    public string? PeerFingerprint { get; set; }
    public TlsRole? Role { get; set; }
    public TlsVersion? TlsVersionMin { get; set; }
}