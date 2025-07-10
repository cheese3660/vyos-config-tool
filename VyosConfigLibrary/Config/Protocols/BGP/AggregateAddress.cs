using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class AggregateAddress : BaseVyosConfigNode<AggregateAddress>
{
    public ConfigFlag? AsSet { get; set; }
    public ConfigFlag? SummaryOnly { get; set; }
}