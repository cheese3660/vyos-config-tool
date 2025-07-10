using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Bridge;

public class BridgeMember : BaseVyosConfigNode<BridgeMember>
{
    public int? Priority { get; set; }
    public int? Cost { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? AllowedVlan { get; set; }
    public string? NativeVlan { get; set; }
}