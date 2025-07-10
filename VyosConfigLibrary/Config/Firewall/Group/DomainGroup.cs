using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Group;

public class DomainGroup : BaseVyosConfigNode<DomainGroup>
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Address { get; set; }
    public string? Description { get; set; }
}