namespace VyosConfigLibrary.Config.Pki;

public class Pki : BaseVyosConfigNode<Pki>
{
    public Dictionary<string, CertificateInfo>? Ca { get; set; }
    public Dictionary<string, CertificateInfo>? Certificate { get; set; }
}