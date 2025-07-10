using VyosConfigLibrary.Config.Interfaces.Components.Ip;
using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall;

public class GlobalOptions : BaseVyosConfigNode<GlobalOptions>
{
    public EnableState? AllPing { get; set; }
    public ApplyToBridgedTraffic? ApplyToBridgedTraffic { get; set; }
    public EnableState? IpSrcRoute { get; set; }
    public EnableState? Ipv6SrcRoute { get; set; }
    public EnableState? ReceiveRedirects { get; set; }
    public EnableState? Ipv6ReceiveRedirects { get; set; }
    public EnableState? SendRedirects { get; set; }
    public EnableState? LogMartians { get; set; }
    public IpSourceValidation? SourceValidation { get; set; }
    public EnableState? SynCookies { get; set; }
    public EnableState? TwaHazardsProtection { get; set; }
    public StatePolicy? StatePolicy { get; set; }
    public Timeout? Timeout { get; set; }
}