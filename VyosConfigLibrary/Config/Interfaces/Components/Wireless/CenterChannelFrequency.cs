using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Interfaces.Components.Wireless;

public class CenterChannelFrequency : BaseVyosConfigNode<CenterChannelFrequency>
{
    [JsonPropertyName("freq-1")]
    public int? Freq1 { get; set; }
    [JsonPropertyName("freq-2")]
    public int? Freq2 { get; set; }
}