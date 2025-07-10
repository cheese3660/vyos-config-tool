using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Container;

public class ContainerRegistry : BaseVyosConfigNode<ContainerRegistry>
{
    public ConfigFlag? Disable { get; set; }
    public Authentication? Authentication { get; set; }
    public ConfigFlag? Insecure { get; set; }
    public ContainerRegistryMirror? Mirror { get; set; }
}