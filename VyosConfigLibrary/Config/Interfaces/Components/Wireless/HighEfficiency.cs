using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Wireless;

public class HighEfficiency : BaseVyosConfigNode<HighEfficiency>
{
    public ConfigFlag? AntennaPatternFixed { get; set; }
    public Beamform? Beamform { get; set; }
    public int? BssColor { get; set; }
    public CenterChannelFrequency? CenterChannelFrequency { get; set; }
    public int? ChannelSetWidth { get; set; }
    public int? CodingScheme { get; set; }
}