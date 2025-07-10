namespace VyosConfigLibrary.Config.Firewall;

public class Firewall : BaseVyosConfigNode<Firewall>
{
    public GlobalOptions? GlobalOptions { get; set; }
    public Group.Group? Group { get; set; }
    public Dictionary<string, FirewallInstance>? Bridge { get; set; }
    public Dictionary<string, FirewallInstance>? Ipv4 { get; set; }
    public Dictionary<string, FirewallInstance>? Ipv6 { get; set; }
    public Dictionary<string, Flowtable>? Flowtable { get; set; }
    public Dictionary<string, Zone.Zone>? Zone { get; set; }
}