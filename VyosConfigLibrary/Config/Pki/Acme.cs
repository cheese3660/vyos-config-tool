namespace VyosConfigLibrary.Config.Pki;

public class Acme : BaseVyosConfigNode<Acme>
{
    public string? DomainName { get; set; }
    public string? Email { get; set; }
    public int? RsaKeySize { get; set; }
    public string? Url { get; set; }
}