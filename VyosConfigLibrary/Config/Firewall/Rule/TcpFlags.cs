using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Rule;

public class TcpFlags : BaseVyosConfigNode<TcpFlags>
{
    public ConfigFlag? Ack { get; set; }
    public ConfigFlag? Cwr { get; set; }
    public ConfigFlag? Ecn { get; set; }
    public ConfigFlag? Fin { get; set; }
    public ConfigFlag? Psh { get; set; }
    public ConfigFlag? Rst { get; set; }
    public ConfigFlag? Syn { get; set; }
    public ConfigFlag? Urg { get; set; }
    public TcpNotFlags? Not { get; set; }
}

public class TcpNotFlags : BaseVyosConfigNode<TcpNotFlags>
{
    public ConfigFlag? Ack { get; set; }
    public ConfigFlag? Cwr { get; set; }
    public ConfigFlag? Ecn { get; set; }
    public ConfigFlag? Fin { get; set; }
    public ConfigFlag? Psh { get; set; }
    public ConfigFlag? Rst { get; set; }
    public ConfigFlag? Syn { get; set; }
    public ConfigFlag? Urg { get; set; }
}