using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Confederation
{
    public string? Identifier { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<int>))]
    public int[]? Peers { get; set; }
}