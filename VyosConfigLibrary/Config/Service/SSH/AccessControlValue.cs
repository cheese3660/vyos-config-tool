using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Service.SSH;

public class AccessControlValue : BaseVyosConfigNode<AccessControlValue>
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Group { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? User { get; set; }
}