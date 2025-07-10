namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Time : BaseVyosConfigNode<Time>
{
    public string? Startdate { get; set; }
    public string? Starttime { get; set; }
    public string? Stopdate { get; set; }
    public string? Stoptime { get; set; }
    private string? Weekdays { get; set; }
}