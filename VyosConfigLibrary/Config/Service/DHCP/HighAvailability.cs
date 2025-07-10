namespace VyosConfigLibrary.Config.Service.DHCP;

public class HighAvailability : BaseVyosConfigNode<HighAvailability>
{
    public HighAvailabilityMode? Mode { get; set; }
    public string? SourceAddress { get; set; }
    public string? Remote { get; set; }
    public string? Name { get; set; }
    public HighAvailabilityStatus? Status { get; set; }
}

public enum HighAvailabilityMode
{
    ActiveActive,
    ActivePassive
}

public enum HighAvailabilityStatus
{
    Primary,
    Secondary
}