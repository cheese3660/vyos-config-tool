using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Firewall.Zone;

public class From : BaseVyosConfigNode<From>
{
    public FromFirewall? Firewall { get; set; }
}

public class FromFirewall : BaseVyosConfigNode<FromFirewall>
{
    public string? Name { get; set; }
    [JsonPropertyName("ipv6-name")]
    public string? Ipv6Name { get; set; }
}