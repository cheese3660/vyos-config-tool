namespace VyosConfigLibrary.Config.Interfaces.Components.Ethernet;

public class RingBuffer : BaseVyosConfigNode<RingBuffer>
{
    public int? Rx { get; set; }
    public int? Tx { get; set; }
}