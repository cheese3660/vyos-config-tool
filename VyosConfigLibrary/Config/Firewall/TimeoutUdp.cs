namespace VyosConfigLibrary.Config.Firewall;

public class TimeoutUdp : BaseVyosConfigNode<TimeoutUdp>
{
    public int? Other { get; set; }
    public int? Stream { get; set; }
}