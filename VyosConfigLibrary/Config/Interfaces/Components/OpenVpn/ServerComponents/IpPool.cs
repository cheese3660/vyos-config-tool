namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn.ServerComponents;

public class IpPool : BaseVyosConfigNode<IpPool>
{
    public string? Start { get; set; }
    public string? Stop { get; set; }
    public string? Subnet { get; set; }

}