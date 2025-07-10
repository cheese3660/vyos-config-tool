using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Interfaces.Components.Bridge;

public enum BridgeProtocol
{
    [JsonStringEnumMemberName("802.1ad")]
    Ieee802OneAd,
    [JsonStringEnumMemberName("802.1q")]
    Ieee802OneQ,
}