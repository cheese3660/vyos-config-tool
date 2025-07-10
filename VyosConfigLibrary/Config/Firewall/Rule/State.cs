using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Rule;

public class State : BaseVyosConfigNode<State>
{
    public ConfigFlag? Established { get; set; }
    public ConfigFlag? Invalid { get; set; }
    public ConfigFlag? New { get; set; }
    public ConfigFlag? Related { get; set; }
}