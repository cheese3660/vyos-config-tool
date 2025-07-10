namespace VyosConfigLibrary.Config.Interfaces.Components.Macsec;

public class SecurityStatic : BaseVyosConfigNode<SecurityStatic>
{
    public string? Key { get; set; }
    public Dictionary<string,Peer>? Peer { get; set; }
}