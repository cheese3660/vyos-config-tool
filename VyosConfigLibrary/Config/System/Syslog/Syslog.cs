using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.System.Syslog;

public class Syslog : BaseVyosConfigNode<Syslog>
{
    public Marker? Marker { get; set; }
    public ConfigFlag? PreserveFqdn { get; set; }
    public string? SourceAddress { get; set; }
    public FacilityList? Local { get; set; }
    public FacilityList? Console { get; set; }
    public Dictionary<string, FacilityList>? Remote { get; set; }
}