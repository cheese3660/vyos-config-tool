using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Wireless;

public class HighThroughput : BaseVyosConfigNode<HighThroughput>
{
    [JsonPropertyName("40mhz-incapable")]
    public ConfigFlag? FortyMhzIncapable { get; set; }
    
    public ConfigFlag? AutoPowersave { get; set; }

    public HighThroughputWidth? ChannelSetWidth { get; set; }
    public ConfigFlag? DelayedBlockAck { get; set; }
    [JsonPropertyName("dss-cck-40")]
    public ConfigFlag? DssCck40 { get; set; }

    public ConfigFlag? Ldpc { get; set; }
    public ConfigFlag? LsigProtection { get; set; }
    public int? MaxAmsdu { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<int>))]
    public int[]? ShortGi { get; set; }

    public PowerSaveSettings? Smps { get; set; }
    
    public SpaceTimeBlockCoding? Stbc { get; set; }
}