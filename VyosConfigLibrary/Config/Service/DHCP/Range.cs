namespace VyosConfigLibrary.Config.Service.DHCP;

public class Range : BaseVyosConfigNode<Range>
{
    public string? Start { get; set; }
    public string? Stop { get; set; }
}