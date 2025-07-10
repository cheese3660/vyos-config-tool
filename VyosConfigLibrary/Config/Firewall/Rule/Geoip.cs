using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Geoip : BaseVyosConfigNode<Geoip>
{
    public string? CountryCode { get; set; }
    public ConfigFlag? InverseMatch {get; set;}
}