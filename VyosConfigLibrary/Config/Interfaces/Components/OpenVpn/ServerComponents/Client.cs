using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn.ServerComponents;

public class Client : BaseVyosConfigNode<Client>
{
    public ConfigFlag? Disable { get; set; }
    public string? Ip { get; set; }
    public string? PushRoute { get; set; }
    public string? Subnet { get; set; }
}