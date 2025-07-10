using VyosConfigLibrary.Config.Interfaces.Components;
using VyosConfigLibrary.Config.Interfaces.Components.Ethernet;

namespace VyosConfigLibrary.Config.Interfaces;

public class Ethernet : BaseInterface<Ethernet>
{
    public EthernetDuplex? Duplex { get; set; }
    public EthernetSpeed? Speed { get; set; }
    public RingBuffer? RingBuffer { get; set; }
    public Offloading? Offload { get; set; }
    public Eapol? Eapol { get; set; }
    public Evpn? Evpn { get; set; }
    public Dictionary<string, Vif>? Vif { get; set; }
    public Dictionary<string, VifS>? VifS { get; set; }
    public PortMirror? Mirror { get; set; }
}