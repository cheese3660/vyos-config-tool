namespace VyosConfigLibrary.Config.Firewall;

public class StatePolicy : BaseVyosConfigNode<StatePolicy>
{
    public StatePolicyState? Established { get; set; }
    public StatePolicyState? Invalid { get; set; }
    public StatePolicyState? Related { get; set; }
}