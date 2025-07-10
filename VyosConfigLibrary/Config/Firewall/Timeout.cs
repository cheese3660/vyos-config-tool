namespace VyosConfigLibrary.Config.Firewall;

public class Timeout : BaseVyosConfigNode<Timeout>
{
    public int? Icmp { get; set; }
    public int? Other { get; set; }
    public TimeoutTcp? Tcp { get; set; }
    public TimeoutUdp? Udp { get; set; }
}