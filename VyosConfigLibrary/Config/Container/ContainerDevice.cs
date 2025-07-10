namespace VyosConfigLibrary.Config.Container;

public class ContainerDevice : BaseVyosConfigNode<ContainerDevice>
{
    public string? Source { get; set; }
    public string? Destination { get; set; }
}