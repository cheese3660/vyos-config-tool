using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class AddressFamily : BaseVyosConfigNode<AddressFamily>
{
    [JsonPropertyName("ipv4-unicast")]
    public AddressFamilyInstance? Ipv4Unicast { get; set; }
    [JsonPropertyName("ipv6-unicast")]
    public AddressFamilyInstance? Ipv6Unicast { get; set; }
}