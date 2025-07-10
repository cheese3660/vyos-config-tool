namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Listen : BaseVyosConfigNode<Listen>
{
    public Dictionary<string, ListenRange>? Range { get; set; }
    public int? Limit { get; set; }
}