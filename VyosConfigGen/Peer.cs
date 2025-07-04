namespace VyosConfigGen;

public class Peer
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PublicKey { get; set; }
    public string PresharedKey { get; set; }
    public string? PublicFromNetwork { get; set; }
    public List<string>? AccessNetworks { get; set; }
}