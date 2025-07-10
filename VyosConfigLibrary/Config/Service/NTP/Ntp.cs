using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Service.NTP;

public class Ntp : BaseVyosConfigNode<Ntp>
{
    public Dictionary<string, Server>? Server { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? ListenAddress {get; set;}
    public AllowClient? AllowClient {get; set;}
    public string? Vrf { get; set; }
    public LeapSecond? LeapSecond { get; set; }
    public Timestamp? Timestamp { get; set; }
    public Ptp? Ptp { get; set; }
}