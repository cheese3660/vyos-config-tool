using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Interfaces.Components.Wireless;

public enum HighThroughputWidth
{
    Ht20,
    [JsonStringEnumMemberName("ht40+")]
    Ht40Plus,
    [JsonStringEnumMemberName("ht40-")]
    Ht40Minus,
}