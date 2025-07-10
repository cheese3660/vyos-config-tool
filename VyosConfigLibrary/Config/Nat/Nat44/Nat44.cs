namespace VyosConfigLibrary.Config.Nat.Nat44;

public class Nat44 : BaseVyosConfigNode<Nat44>
{
    public NatRuleList? Source { get; set; }
    public NatRuleList? Destination { get; set; }
}