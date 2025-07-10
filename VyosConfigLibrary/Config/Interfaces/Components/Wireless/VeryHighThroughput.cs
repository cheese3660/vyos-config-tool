using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Wireless;

public class VeryHighThroughput : BaseVyosConfigNode<VeryHighThroughput>
{
    public int? AntennaCount { get; set; }
    public ConfigFlag? AntennaPatternFixed { get; set; }
    public Beamform? Beamform { get; set; }
    public CenterChannelFrequency? CenterChannelFreq { get; set; }
    public int? ChannelSetWidth { get; set; }
    public ConfigFlag? Ldpc { get; set; }
    public ConfigFlag? LinkAdaptation { get; set; }
    public int? MaxMpdu { get; set; }
    public int? MaxMpduExp { get; set; }
    public int? ShortGi { get; set; }
    public SpaceTimeBlockCoding? Stbc { get; set; }
    public ConfigFlag? TxPowersave { get; set; }
    public ConfigFlag? VhtCf { get; set; }
    
}