namespace VyosConfigLibrary.Config.Protocols.BGP;

public class RedistributeSource : BaseVyosConfigNode<RedistributeSource>
{
    public int? Metric { get; set; }
    public string? RouteMap { get; set; }
}