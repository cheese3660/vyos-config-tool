namespace VyosConfigLibrary.Config.Firewall;

public class TimeoutTcp : BaseVyosConfigNode<TimeoutTcp>
{
    public int? Close { get; set; }
    public int? CloseWait { get; set; }
    public int? Established { get; set; }
    public int? FinWait { get; set; }
    public int? LastAck { get; set; }
    public int? SynRecv { get; set; }
    public int? SynSent { get; set; }
    public int? TimeWait { get; set; }
}