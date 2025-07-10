namespace VyosConfigLibrary.Config.Service.HTTPS;

public class Certificates : BaseVyosConfigNode<Certificates>
{
    public string? CaCertificate { get; set; }
    public string? Certificate { get; set; }
    public string? DhParams { get; set; }
    
}