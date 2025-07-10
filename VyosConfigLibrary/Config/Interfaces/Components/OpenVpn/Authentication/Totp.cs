namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn.Authentication;

public class Totp : BaseVyosConfigNode<Totp>
{
    public Challenge? Challenge { get; set; }
    public int? Digits { get; set; }
    public int? Drift { get; set; }
    public int? Slop { get; set; }
}