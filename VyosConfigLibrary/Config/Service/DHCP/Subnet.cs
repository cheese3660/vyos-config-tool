using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Service.DHCP;

public class Subnet : BaseVyosConfigNode<Subnet>
{
    public string? SubnetId { get; set; }
    public int? Lease { get; set; }
    public Option? Option { get; set; }
    public Dictionary<string, Range>? Range { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Exclude { get; set; }
    public Dictionary<string, StaticMapping>? StaticMapping { get; set; }
}