namespace VyosConfigGen;

public class Wireguard
{
    public string PrivateKey { get; set; }
    public string Address { get; set; }
    public int Port { get; set; }
    public string EndpointAddr { get; set; }
    public List<Peer> Peers { get; set; } = [];
}