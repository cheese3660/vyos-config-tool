using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Group;

public class PortGroup
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Port { get; set; }
    public string? Description { get; set; }
}