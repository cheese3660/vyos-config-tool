namespace VyosConfigLibrary.Config.Interfaces.Components.Dhcp;

public class DhcpV6Delegetee : BaseVyosConfigNode<DhcpV6Delegetee>
{
    public int? Address { get; set; }
    public int? SlaId { get; set; }
}