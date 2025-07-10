namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Limit : BaseVyosConfigNode<Limit>
{
    public uint? Burst { get; set; }
    public string? Rate { get; set; }
}