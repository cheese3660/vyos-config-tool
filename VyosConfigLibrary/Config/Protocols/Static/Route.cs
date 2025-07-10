using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.Static;

public class Route : BaseVyosConfigNode<Route>
{
    public Dictionary<string, NextHop>? NextHop { get; set; }
    public Dictionary<string, NextHop>? Interface { get; set; }
    public string? DhcpInterface { get; set; }
    public Reject? Reject { get; set; }
    public Reject? Blackhole { get; set; }
}