namespace VyosConfigLibrary.Config.Nat.Nat44;

public class NatRuleList : BaseVyosConfigNode<NatRuleList>
{
    public Dictionary<string, Rule>? Rule { get; set; }
}