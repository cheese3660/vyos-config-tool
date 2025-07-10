namespace VyosConfigLibrary.Config.Interfaces.Components.Ethernet;

public class Eapol : BaseVyosConfigNode<Eapol>
{
    public string? CaCertificate { get; set; }
    public string? Certificate { get; set; }
}