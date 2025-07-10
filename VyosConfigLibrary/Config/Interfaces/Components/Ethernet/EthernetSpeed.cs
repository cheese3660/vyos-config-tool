using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Interfaces.Components.Ethernet;

public enum EthernetSpeed
{
    Auto,
    [JsonStringEnumMemberName("10")]
    TenMegabit,
    [JsonStringEnumMemberName("100")]
    HundredMegabit,
    [JsonStringEnumMemberName("1000")]
    Gigabit,
    [JsonStringEnumMemberName("2500")]
    TwoPointFiveGigabit,
    [JsonStringEnumMemberName("5000")]
    FiveGigabit,
    [JsonStringEnumMemberName("10000")]
    TenGigabit,
    [JsonStringEnumMemberName("25000")]
    TwentyFiveGigabit,
    [JsonStringEnumMemberName("40000")]
    FortyGigabit,
    [JsonStringEnumMemberName("50000")]
    FiftyGigabit,
    [JsonStringEnumMemberName("100000")]
    HundredGigabit,
}