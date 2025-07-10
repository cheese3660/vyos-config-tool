using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Neighbor : BaseVyosConfigNode<Neighbor>
{
    public string? RemoteAs { get; set; }
    public Dictionary<string, LocalRole>? LocalRole { get; set; }
    public ConfigFlag? Shutdown { get; set; }
    public string? Description { get; set; }
    public string? UpdateSource { get; set; }
    public Capability? Capability { get; set; }
    public ConfigFlag? DisableCapabilityNegotiation { get; set; }
    public ConfigFlag? OverrideCapability { get; set; }
    public ConfigFlag? StrictCapabilityMatch { get; set; }
    public AddressFamily? AddressFamily { get; set; }
    public int? AdvertisementInterval { get; set; }
    public ConfigFlag? DisableConnectedCheck { get; set; }
    public int? EbgpMultihop { get; set; }
    public Dictionary<string, LocalAs>? LocalAs { get; set; }
    public ConfigFlag? Passive { get; set; }
    public string? Password { get; set; }
    public int? TtlSecurityHops { get; set; }
    public string? PeerGroup { get; set; }
    public ConfigFlag? Solo { get; set; }
}