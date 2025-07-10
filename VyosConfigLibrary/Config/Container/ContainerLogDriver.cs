using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Container;

public enum ContainerLogDriver
{
    [JsonStringEnumMemberName("k8s-file")]
    K8sFile,
    Journald,
    None
}