using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class AttributeUnchanged : BaseVyosConfigNode<AttributeUnchanged>
{
    public ConfigFlag? AsPath { get; set; }
    public ConfigFlag? Med { get; set; }
    public ConfigFlag? NextHop { get; set; }
}