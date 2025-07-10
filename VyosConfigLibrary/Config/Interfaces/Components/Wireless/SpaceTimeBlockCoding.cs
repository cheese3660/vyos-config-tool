using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Wireless;

public class SpaceTimeBlockCoding : BaseVyosConfigNode<SpaceTimeBlockCoding>
{
    public int? Rx { get; set; }
    public ConfigFlag? Tx { get; set; }
}