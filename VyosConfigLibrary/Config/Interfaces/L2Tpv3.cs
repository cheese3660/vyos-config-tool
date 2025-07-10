using VyosConfigLibrary.Config.Interfaces.Components.L2Tpv3;

namespace VyosConfigLibrary.Config.Interfaces;

public class L2Tpv3 : BaseInterface<L2Tpv3>
{
    public Encapsulation? Encapsulation { get; set; }
    public string? SourceAddress { get; set; }
    public string? Remote { get; set; }
    public int? SessionId { get; set; }
    public int? PeerSessionId { get; set; }
    public int? TunnelId { get; set; }
    public int? PeerTunnelId { get; set; }
}