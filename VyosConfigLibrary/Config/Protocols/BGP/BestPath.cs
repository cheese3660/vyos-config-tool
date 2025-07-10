using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class BestPath : BaseVyosConfigNode<BestPath>
{
    public AsPath? AsPath { get; set; }
    public Med? Med { get; set; }
    public ConfigFlag? CompareRouterid { get; set; }
}