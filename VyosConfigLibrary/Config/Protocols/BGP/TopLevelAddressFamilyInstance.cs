namespace VyosConfigLibrary.Config.Protocols.BGP;

public class TopLevelAddressFamilyInstance : BaseVyosConfigNode<TopLevelAddressFamilyInstance>
{
    public Dictionary<string, NetworkBackdoor>? Network { get; set; }
    public Dictionary<string, AggregateAddress>? AggregateAddress { get; set; }
    public Redistribute? Redistribute { get; set; }
    public MaximumPaths? MaximumPaths { get; set; }
}