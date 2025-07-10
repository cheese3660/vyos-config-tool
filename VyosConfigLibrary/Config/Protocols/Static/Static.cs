using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Protocols.Static;

public class Static : BaseVyosConfigNode<Static>
{
    public Dictionary<string, Route>? Route { get; set; }
    [JsonPropertyName("route6")]
    public Dictionary<string, Route>? Route6 { get; set; }
}