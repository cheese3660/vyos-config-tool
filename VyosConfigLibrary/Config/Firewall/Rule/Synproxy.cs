namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Synproxy
{
    public SynproxyTcp? Tcp { get; set; }
}

public class SynproxyTcp : BaseVyosConfigNode<SynproxyTcp>
{
    public int? Mss { get; set; }
    public int? WindowScale { get; set; }
}