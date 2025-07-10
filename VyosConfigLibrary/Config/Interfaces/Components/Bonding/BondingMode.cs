using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Interfaces.Components.Bonding;

public enum BondingMode
{
    [JsonStringEnumMemberName("802.3ad")]
    Ieee8023Ad,
    ActiveBackup,
    Broadcast,
    RoundRobin,
    TransmitLoadBalance,
    AdaptiveLoadBalance,
    XorHash
}