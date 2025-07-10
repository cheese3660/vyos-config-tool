using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Service.SSH;

public class DynamicProtection : BaseVyosConfigNode<DynamicProtection>
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? AllowFrom { get; set; }

    public int? BlockTime { get; set; }
    public int? DetectTime { get; set; }
    public int? Threshold { get; set; }
}