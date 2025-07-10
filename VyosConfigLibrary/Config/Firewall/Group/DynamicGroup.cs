namespace VyosConfigLibrary.Config.Firewall.Group;

public class DynamicGroup : BaseVyosConfigNode<DynamicGroup>
{
    public Dictionary<string, DynamicGroupInstance>? AddressGroup { get; set; }
    public Dictionary<string, DynamicGroupInstance>? Ipv6AddressGroup { get; set; }
}