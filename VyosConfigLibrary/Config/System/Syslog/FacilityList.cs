namespace VyosConfigLibrary.Config.System.Syslog;

public class FacilityList : BaseVyosConfigNode<FacilityList>
{
    public Dictionary<string, Facility>? Facility { get; set; }
    public string? Protocol { get; set; }
    public int? Port { get; set; }
    public Format? Format { get; set; }
    public string? Vrf { get; set; }
    public string? SourceAddress { get; set; }
}