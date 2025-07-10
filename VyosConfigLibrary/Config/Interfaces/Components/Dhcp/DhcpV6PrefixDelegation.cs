namespace VyosConfigLibrary.Config.Interfaces.Components.Dhcp;

public class DhcpV6PrefixDelegation : BaseVyosConfigNode<DhcpV6PrefixDelegation>
{
    public int? Length { get; set; }
}