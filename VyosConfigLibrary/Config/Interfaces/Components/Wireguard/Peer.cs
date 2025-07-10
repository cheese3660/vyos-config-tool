using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Wireguard;

public class Peer : BaseVyosConfigNode<Peer>
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? AllowedIps { get; set; }

    public string? Address { get; set; }
    public int? Port { get; set; }
    public string? PublicKey { get; set; }
    public string? PresharedKey { get; set; }
}