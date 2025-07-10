using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Interfaces;

public class Interfaces : BaseVyosConfigNode<Interfaces>
{
    public Dictionary<string, Bonding>? Bonding { get; set; }
    public Dictionary<string, Bridge>? Bridge { get; set; }
    public Dictionary<string, Dummy>? Dummy { get; set; }
    public Dictionary<string, Ethernet>? Ethernet { get; set; }
    public Dictionary<string, Geneve>? Geneve { get; set; }
    [JsonPropertyName("l2tpv3")] public Dictionary<string, L2Tpv3>? L2Tpv3 { get; set; }
    public Dictionary<string, Loopback>? Loopback { get; set; }
    public Dictionary<string, Macsec>? Macsec { get; set; }
    public Dictionary<string, Wireguard>? Wireguard { get; set; }
    public Dictionary<string, Pppoe>? Pppoe { get; set; }
    public Dictionary<string, Sstpc>? Sstpc { get; set; }
    public Dictionary<string, Tunnel>? Tunnel { get; set; }
    public Dictionary<string, VirtualEthernet>? VirtualEthernet { get; set; }
    public Dictionary<string, Vti>? Vti { get; set; }
    public Dictionary<string, Vxlan>? Vxlan { get; set; }
    public Dictionary<string, Wireless>? Wireless { get; set; }
    public Dictionary<string, Wwan>? Wwan { get; set; }
}