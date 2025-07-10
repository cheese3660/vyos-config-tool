using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class SoftReconfiguration : BaseVyosConfigNode<SoftReconfiguration>
{
    public ConfigFlag? Inbound { get; set; }
}