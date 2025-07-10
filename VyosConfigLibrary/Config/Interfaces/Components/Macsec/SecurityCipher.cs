using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Interfaces.Components.Macsec;

public enum SecurityCipher
{
    [JsonStringEnumMemberName("gcm-aes-128")]
    GcmAes128,
    [JsonStringEnumMemberName("gcm-aes-256")]
    GcmAes256
}