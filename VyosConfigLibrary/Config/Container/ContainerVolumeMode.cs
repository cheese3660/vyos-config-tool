using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Container;

public enum ContainerVolumeMode
{
    [JsonStringEnumMemberName("ro")]
    ReadOnly,
    [JsonStringEnumMemberName("rw")]
    ReadWrite,
}