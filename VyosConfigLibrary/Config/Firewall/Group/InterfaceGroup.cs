using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Group;

public class InterfaceGroup
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Interface { get; set; }

    public string? Description { get; set; }
}