using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall;

public class ApplyToBridgedTraffic : BaseVyosConfigNode<ApplyToBridgedTraffic>
{
    public ConfigFlag? Ipv4 { get; set; }
    public ConfigFlag? Ipv6 { get; set; }
}