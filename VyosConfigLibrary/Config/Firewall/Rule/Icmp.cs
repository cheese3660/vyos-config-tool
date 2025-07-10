namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Icmp : BaseVyosConfigNode<Icmp>
{
    public int? Code { get; set; }
    public int? Type { get; set; }
    public string? TypeName { get; set; }
}