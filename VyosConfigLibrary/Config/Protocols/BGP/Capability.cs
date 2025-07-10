using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Capability : BaseVyosConfigNode<Capability>
{
    public ConfigFlag? Dynamic { get; set; }
    public ConfigFlag? ExtendedNextHop { get; set; }
}