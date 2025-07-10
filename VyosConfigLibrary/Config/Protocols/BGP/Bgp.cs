namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Bgp : BaseVyosConfigNode<Bgp>
{
    public int? SystemAs { get; set; }
    public Dictionary<string, Neighbor>? Neighbor { get; set; }
    public Dictionary<string, Neighbor>? PeerGroup { get; set; }
    public TopLevelAddressFamily? AddressFamily { get; set; }
    public Parameters? Parameters { get; set; }
    public Listen? Listen { get; set; }
    public Timers? Timers { get; set; }
}