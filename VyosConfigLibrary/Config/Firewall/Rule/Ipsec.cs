using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Ipsec : BaseVyosConfigNode<Ipsec>
{
    public ConfigFlag? MatchIpsecIn { get; set; }
    public ConfigFlag? MatchIpsecOut { get; set; }
    public ConfigFlag? MatchNoneIn { get; set; }
    public ConfigFlag? MatchNoneOut { get; set; }
}