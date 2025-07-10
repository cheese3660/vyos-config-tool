using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Med : BaseVyosConfigNode<Med>
{
    public ConfigFlag? MissingAsWorst { get; set; }
    public ConfigFlag? Confed { get; set; }
}