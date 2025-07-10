using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class LocalRole : BaseVyosConfigNode<LocalRole>
{
    public ConfigFlag? Strict { get; set; }
}