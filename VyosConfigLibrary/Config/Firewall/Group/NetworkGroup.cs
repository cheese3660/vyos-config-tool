using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Group;

public class NetworkGroup : BaseVyosConfigNode<NetworkGroup>
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Network { get; set; }
    public string? Description { get; set; }
}