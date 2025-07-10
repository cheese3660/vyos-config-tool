using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Ethernet;

public class Offloading : BaseVyosConfigNode<Offloading>
{
    public ConfigFlag? Gro { get; set; }
    public ConfigFlag? Gso { get; set; }
    public ConfigFlag? Lro { get; set;}
    public ConfigFlag? Sg { get; set; }
    public ConfigFlag? Tso { get; set; }
}