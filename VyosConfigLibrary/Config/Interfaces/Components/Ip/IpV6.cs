using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Ip;

public class IpV6 : BaseVyosConfigNode<IpV6>
{
    public IpV6Address? Address { get; set; }

    public ConfigFlag? DisableForwarding { get; set; }

    public int? AcceptDad { get; set; }
    
    public int? DupAddrDetectTransmits { get; set; }
}