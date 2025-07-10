namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Dampening : BaseVyosConfigNode<Dampening>
{
    public int? HalfLife { get; set; }
    public int? ReUse { get; set; }
    public int? StartSuppressTime { get; set; }
    public int? MaxSuppressTime { get; set; }
}