using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Bridge;

public class Igmp : BaseVyosConfigNode<Igmp>
{
    public ConfigFlag? Querier { get; set; }
    public ConfigFlag? Snooping { get; set; }
}