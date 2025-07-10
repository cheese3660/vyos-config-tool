using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Service.DHCP;

public class DynamicDnsUpdate : BaseVyosConfigNode<DynamicDnsUpdate>
{
    public EnableState? SendUpdates { get; set; }
    public EnableState? OverrideNoUpdate { get; set; }
    public EnableState? UpdateOnRenew { get; set; }
    public EnableState? ConflictResolution { get; set; }
    public ReplaceClientName? ReplaceClientName { get; set; }
    public string? GeneratedPrefix { get; set; }
    public string? QualifyingSuffix { get; set; }
    public int? TtlPercent { get; set; }
    public string? HostnameCharSet { get; set; }
    public string? HostnameCharReplacement { get; set; }
    public Dictionary<string, TsigKey>? TsigKey { get; set; }
    public Dictionary<string, Domain>? ForwardDomain { get; set; }
    public Dictionary<string, Domain>? ReverseDomain { get; set; }
}

public enum ReplaceClientName
{
    Never,
    Always,
    WhenPresent,
    WhenNotPresent,
}