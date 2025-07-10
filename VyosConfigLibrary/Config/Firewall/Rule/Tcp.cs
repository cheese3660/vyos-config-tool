namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Tcp : BaseVyosConfigNode<Tcp>
{
    public TcpFlags? Flags { get; set; }
}