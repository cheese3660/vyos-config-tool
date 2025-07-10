using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Ethernet;

public class Evpn : BaseVyosConfigNode<Evpn>
{
    public ConfigFlag? Uplink { get; set; }
}