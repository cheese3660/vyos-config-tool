using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Fragment : BaseVyosConfigNode<Fragment>
{
    public ConfigFlag? MatchFrag { get; set; }
    public ConfigFlag? MatchNonFrag { get; set; }
}