using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn.ServerComponents;

public class Bridge : BaseVyosConfigNode<Bridge>
{
    public ConfigFlag? Disable { get; set; }
    public string? Gateway { get; set; }
    public string? Start { get; set; }
    public string? Stop { get; set; }
    public string? SubnetMask { get; set; }
}