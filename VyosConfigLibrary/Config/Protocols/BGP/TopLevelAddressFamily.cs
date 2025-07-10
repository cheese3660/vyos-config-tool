using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class TopLevelAddressFamily : BaseVyosConfigNode<TopLevelAddressFamily>
{
    [JsonPropertyName("ipv4-unicast")]
    public TopLevelAddressFamilyInstance? Ipv4Unicast { get; set; }
    [JsonPropertyName("ipv6-unicast")]
    public TopLevelAddressFamilyInstance? Ipv6Unicast { get; set; }
}