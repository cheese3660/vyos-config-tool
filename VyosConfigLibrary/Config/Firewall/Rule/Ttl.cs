namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Ttl : BaseVyosConfigNode<Ttl>
{
    public int? Eq { get; set; }
    public int? Gt { get; set; }
    public int? Lt { get; set; }
}