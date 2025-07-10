using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn;

public enum TlsVersion
{
    [JsonStringEnumMemberName("1.0")]
    OnePointZero,
    [JsonStringEnumMemberName("1.1")]
    OnePointOne,
    [JsonStringEnumMemberName("1.2")]
    OnePointTwo,
    [JsonStringEnumMemberName("1.4")]
    OnePointFour,
}