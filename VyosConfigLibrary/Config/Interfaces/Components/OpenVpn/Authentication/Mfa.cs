namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn.Authentication;

public class Mfa : BaseVyosConfigNode<Mfa>
{
    public Totp Totp { get; set; }
}