namespace VyosConfigLibrary.Config.Interfaces.Components.Bonding;

public class ArpMonitor : BaseVyosConfigNode<ArpMonitor>
{
    public int? Interval { get; set; }
    public string? Target { get; set; }
}