namespace VyosConfigLibrary.Config.Protocols.BGP;

public class MaximumPaths : BaseVyosConfigNode<MaximumPaths>
{
    public int? Ebgp { get; set; }
    public int? Ibgp { get; set; }
}