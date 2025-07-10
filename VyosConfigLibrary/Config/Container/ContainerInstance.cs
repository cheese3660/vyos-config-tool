using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Container;

public class ContainerInstance : BaseVyosConfigNode<ContainerInstance>
{
    public string? Image { get; set; }
    public string? Entrypoint { get; set; }
    public string? Command { get; set; }
    public string? Arguments { get; set; }
    public string? HostName { get; set; }
    public ConfigFlag? AllowHostPid { get; set; }
    public ConfigFlag? AllowHostNetworks { get; set; }
    public Dictionary<string,ContainerInstanceNetwork>? Network { get; set; }
    public string? NameServer { get; set; }
    public string? Description { get; set; }
    public Dictionary<string, ConfigValue>? Environment { get; set; }
    public Dictionary<string, ContainerPort>? Port { get; set; }
    public Dictionary<string, ContainerVolume>? Volume { get; set; }
    public Dictionary<string, ContainerTmpfs>? Tmpfs { get; set; }
    public int? Uid { get; set; }
    public int? GId { get; set; }
    public ContainerRestart? Restart { get; set; }
    public float? CpuQuota { get; set; }
    public int? Memory { get; set; }
    public Dictionary<string, ContainerDevice>? Device { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Capability { get; set; }
    public ContainerSysctl? Sysctl { get; set; }
    public Dictionary<string, ConfigValue>? Label { get; set; }
    public ConfigFlag? Disable { get; set; }
    public ContainerLogDriver? LogDriver { get; set; }
}