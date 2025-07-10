using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Service.DHCP;

public class SharedNetwork : BaseVyosConfigNode<SharedNetwork>
{
    public Option? Option { get; set; }
    public ConfigFlag? Authoritative { get; set; }
    public Dictionary<string, Subnet>? Subnet { get; set; }
}