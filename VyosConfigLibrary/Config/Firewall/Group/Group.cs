namespace VyosConfigLibrary.Config.Firewall.Group;

public class Group : BaseVyosConfigNode<Group>
{
    public Dictionary<string, AddressGroup>? AddressGroup { get; set; }
    public Dictionary<string, AddressGroup>? Ipv6AddressGroup { get; set; }
    public Dictionary<string, RemoteGroup>? RemoteGroup { get; set; }
    public Dictionary<string, NetworkGroup>? NetworkGroup { get; set; }
    public Dictionary<string, NetworkGroup>? Ipv6NetworkGroup { get; set; }
    public Dictionary<string, InterfaceGroup>? InterfaceGroup { get; set; }
    public Dictionary<string, PortGroup>? PortGroup { get; set; }
    public Dictionary<string, MacGroup>? MacGroup { get; set; }
    public Dictionary<string, DomainGroup>? DomainGroup { get; set; }
}