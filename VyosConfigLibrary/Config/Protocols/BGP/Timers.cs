namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Timers : BaseVyosConfigNode<Timers>
{
    public int? Holdtime { get; set; }
    public int? Keepalive {get; set;}
}