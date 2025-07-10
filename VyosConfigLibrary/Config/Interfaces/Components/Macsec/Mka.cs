namespace VyosConfigLibrary.Config.Interfaces.Components.Macsec;

public class Mka : BaseVyosConfigNode<Mka>
{
    public string? Ckn { get; set; }
    public int? Priority { get; set; }
}