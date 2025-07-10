using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Group;

public class MacGroup : BaseVyosConfigNode<MacGroup>
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? MacAddress { get; set; }
    public string? Description { get; set; }
}