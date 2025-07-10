using System.Net;
using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Interfaces.Components.Bridge;
using VyosConfigLibrary.Config.Interfaces.Components.Dhcp;
using VyosConfigLibrary.Config.Interfaces.Components.Ip;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class BaseInterface<T> : BaseVyosConfigNode<T> where T : BaseVyosConfigNode<T>, new()
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Address { get; set; }

    public string? Description { get; set; }

    public ConfigFlag? Disable { get; set; }
    public ConfigFlag? DisableFlowControl { get; set; }
    
    public ConfigFlag? DisableLinkDetect { get; set; }
    
    public string? Mac { get; set; }
    
    public int? Mtu { get; set; }
    
    public Ip? Ip {get; set;}
    
    public IpV6? Ipv6 { get; set; }
    
    public DhcpOptions? DhcpOptions { get; set; }
    
    public DhcpOptionsV6? DhcpV6Options { get; set; }

    public string? Vrf { get; set; }
}