using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Interfaces.Components.Bonding;

public enum BondingHashPolicy
{
    [JsonStringEnumMemberName("layer2")]
    Layer2,
    [JsonStringEnumMemberName("layer2+3")]
    Layer2Plus3,
    [JsonStringEnumMemberName("layer3+4")]
    Layer3Plus4,
}