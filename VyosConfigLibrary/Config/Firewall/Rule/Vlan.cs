namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Vlan : BaseVyosConfigNode<Vlan>
{
    public string? EthernetType { get; set; }
    public int? Id { get; set; }
    public int? Priority { get; set; }
}