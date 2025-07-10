using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn;

public class Encryption : BaseVyosConfigNode<Encryption>
{
    public string? Cipher { get; set; }

    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? DataCiphers { get; set; }
}