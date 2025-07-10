using VyosConfigLibrary.Config.Interfaces.Components.OpenVpn.Authentication;
using VyosConfigLibrary.Config.Interfaces.Components.OpenVpn.ServerComponents;
using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn;

public class Server : BaseVyosConfigNode<Server>
{
    public ServerComponents.Bridge? Bridge { get; set; }
    public Dictionary<string, Client>? Client { get; set; }
    public IpPool? ClientIpPool { get; set; }
    public IpPoolV6? ClientIpv6Pool { get; set; }
    public string? DomainName { get; set; }
    public int? MaxConnections { get; set; }
    public Mfa? Mfa { get; set; }
    public string? NameServer { get; set; }
    public string? PushRoute { get; set; }
    public ConfigFlag? RejectUnconfiguredClient { get; set; }
    public string? Subnet { get; set; }
    public Topology? Topology { get; set; }
}