using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Service.HTTPS;

public class AllowClient : BaseVyosConfigNode<AllowClient>
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Address { get; set; }
}