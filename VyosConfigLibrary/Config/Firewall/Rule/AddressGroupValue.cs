using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Rule;

public class AddressGroupValue : BaseVyosConfigNode<AddressGroupValue>
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? AddressGroup { get; set; }
    public string? Timeout { get; set; }
}