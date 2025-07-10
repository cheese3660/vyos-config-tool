using VyosConfigLibrary.Config.Protocols.BGP;

namespace VyosConfigLibrary.Config.Protocols;

public class Protocols : BaseVyosConfigNode<Protocols>
{
    // TODO: ARP
    // TODO: Babel
    // TODO: BFD
    public Bgp? Bgp { get; set; }
    // TODO: Fallover
    // TODO: IGMP Proxy
    // TODO: IS-IS
    // TODO: MPLS
    // TODO: Multicast
    // TODO: Segment Routing
    // TODO: OpenFabric
    // TODO: OSPF
    // TODO: PIM
    // TODO: PIM6
    // TODO: RIP
    // TODO: RPKI
    public Static.Static? Static { get; set; }
}