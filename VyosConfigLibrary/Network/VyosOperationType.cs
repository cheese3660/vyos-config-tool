using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Network;

public enum VyosOperationType
{
    None,
    [JsonStringEnumMemberName("showConfig")]
    ShowConfig,
    [JsonStringEnumMemberName("returnValues")]
    ReturnValues,
    [JsonStringEnumMemberName("exists")]
    Exists,
    [JsonStringEnumMemberName("reset")]
    Reset,
    [JsonStringEnumMemberName("reboot")]
    Reboot,
    [JsonStringEnumMemberName("poweroff")]
    PowerOff,
    [JsonStringEnumMemberName("add")]
    Add,
    [JsonStringEnumMemberName("delete")]
    Delete,
    [JsonStringEnumMemberName("show")]
    Show,
    [JsonStringEnumMemberName("generate")]
    Generate,
    [JsonStringEnumMemberName("set")]
    Set,
    [JsonStringEnumMemberName("save")]
    Save,
    [JsonStringEnumMemberName("load")]
    Load,
    [JsonStringEnumMemberName("merge")]
    Merge
}