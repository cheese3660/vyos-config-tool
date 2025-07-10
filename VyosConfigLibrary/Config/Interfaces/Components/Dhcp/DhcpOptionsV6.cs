using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Dhcp;

public class DhcpOptionsV6 : BaseDhcpOptions<DhcpOptionsV6>
{
    public string? Duid { get; set; }
    public ConfigFlag? NoRelease { get; set; }

    public ConfigFlag? ParametersOnly { get; set; }

    public ConfigFlag? RapidCommit { get; set; }

    public ConfigFlag? Temporary { get; set; }

    public Dictionary<string, DhcpV6PrefixDelegation>? Pd { get; set; } = new();

    public Dictionary<string, DhcpV6Delegetee>? Interface { get; set; } = new();
}