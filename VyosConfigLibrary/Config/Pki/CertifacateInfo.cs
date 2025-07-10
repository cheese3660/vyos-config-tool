namespace VyosConfigLibrary.Config.Pki;

public class CertificateInfo : BaseVyosConfigNode<CertificateInfo>
{
    public string? Certificate { get; set; }
    public string? Description { get; set; }
    public Acme? Acme { get; set; }
    public Private? Private { get; set; }
}