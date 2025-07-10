using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Interfaces.Components;
using VyosConfigLibrary.Config.Interfaces.Components.OpenVpn;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class OpenVpn : BaseInterface<OpenVpn>
{
    public Authentication? Authentication { get; set; }
    public Encryption? Encryption { get; set; }
    public string? Hash { get; set; }
    public KeepAlive? KeepAlive { get; set; }
    public string? LocalAddress { get; set; }
    public string? LocalHost { get; set; }
    public int? LocalPort { get; set; }
    public PortMirror? Mirror { get; set; }
    public OpenVpnMode Mode { get; set; }
    public Offloading? Offload { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? OpenvpnOption { get; set; }
    public ConfigFlag? PersistentTunnel { get; set; }
    public Protocol? Protocol { get; set; }
    public string? Redirect { get; set; }
    public string? RemoteAddress { get; set; }
    public string? RemoteHost { get; set; }
    public int? RemotePort { get; set; }
    public ConfigFlag? ReplaceDefaultRute { get; set; }
    public string? SharedSecretKey { get; set; }
    public Server? Server { get; set; }
    public Tls? Tls { get; set; }
    public ConfigFlag? UserLzoCompression { get; set; }
}