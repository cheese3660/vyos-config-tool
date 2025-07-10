using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Ip;

public class IpV6Address : BaseVyosConfigNode<IpV6Address>
{
    public ConfigFlag? Autoconf { get; set; }
    [JsonPropertyName("eui64"), JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Eui64 { get; set; }
    public ConfigFlag? NoDefaultLinkLocal {get; set;}
}