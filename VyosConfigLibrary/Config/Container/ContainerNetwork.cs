using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Container;

public class ContainerNetwork : BaseVyosConfigNode<ContainerNetwork>
{
    public string? Description { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Prefix { get; set; }
    public int? Mtu { get; set; }
    public ConfigFlag? NoNameServer { get; set; }
    public string? Vrf { get; set; }
}