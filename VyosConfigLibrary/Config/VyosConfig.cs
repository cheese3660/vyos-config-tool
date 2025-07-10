using VyosConfigLibrary.Config.Nat.Nat44;

namespace VyosConfigLibrary.Config;

public class VyosConfig : BaseVyosConfigNode<VyosConfig>
{
    public Container.Container? Container { get; set; }
    public Firewall.Firewall? Firewall { get; set; }
    // TODO: High Availability
    public Interfaces.Interfaces? Interfaces { get; set; }
    // TODO: Load Balancing
    public Nat44? Nat { get; set; }
    // TODO: Nat64
    // TODO: Nat66
    // TODO: Policy
    public Pki.Pki? Pki { get; set; }
    public Protocols.Protocols? Protocols { get; set; }
    public Service.Service? Service { get; set; }
    public System.System? System { get; set; }
}