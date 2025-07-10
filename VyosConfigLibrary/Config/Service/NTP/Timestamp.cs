namespace VyosConfigLibrary.Config.Service.NTP;

public class Timestamp : BaseVyosConfigNode<Timestamp>
{
    public string? Interface { get; set; }
    public ReceiveFilter? ReceiveFilter { get; set; }
}

public enum ReceiveFilter
{
    All,
    Ntp,
    Ptp,
    None
}