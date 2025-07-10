namespace VyosConfigLibrary.Config.Container;

public class ContainerRegistryMirror : BaseVyosConfigNode<ContainerRegistryMirror>
{
    public string? Address { get; set; }
    public string? HostName { get; set; }
    public int? Port { get; set; }
    public string? Path { get; set; }
}