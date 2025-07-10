using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class AsPath : BaseVyosConfigNode<AsPath>
{
    public ConfigFlag? Confed { get; set; }
    public ConfigFlag? MultipathRelax { get; set; }
    public ConfigFlag? Ignore { get; set; }
    
}