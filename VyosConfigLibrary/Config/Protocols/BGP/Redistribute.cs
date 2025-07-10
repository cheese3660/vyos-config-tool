namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Redistribute : BaseVyosConfigNode<Redistribute>
{
    public RedistributeSource? Connected { get; set; }
    public RedistributeSource? Kernel { get; set; }
    public RedistributeSource? Ospf { get; set; }
    public RedistributeSource? Rip { get; set; }
    public RedistributeSource? Static { get; set; }
    public RedistributeSource? Table { get; set; }
}