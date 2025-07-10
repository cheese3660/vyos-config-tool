using VyosConfigLibrary.Config.Interfaces.Components.Wireguard;
using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class Wireguard : BaseInterface<Wireguard>
{
    public string? PrivateKey { get; set; }
    public int? Port { get; set; }
    public ConfigFlag? PerClientThread { get; set; }
    public Dictionary<string, Peer> Peer { get; set; }
}