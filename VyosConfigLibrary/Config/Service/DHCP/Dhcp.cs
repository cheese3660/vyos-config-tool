using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Service.DHCP;

public class Dhcp : BaseVyosConfigNode<Dhcp>
{
    public ConfigFlag? HostFileUpdate { get; set; }
    public Dictionary<string, SharedNetwork>? SharedNetworkName { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? ListenAddress {get; set;}
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? ListenInterface {get; set;}

    public DynamicDnsUpdate? DynamicDnsUpdate { get; set; }
    public HighAvailability? HighAvailability { get; set; }
    
}