using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Container;

public class ContainerSysctl : BaseVyosConfigNode<ContainerSysctl>
{
    public Dictionary<string, ConfigValue>? Parameter { get; set; }
}