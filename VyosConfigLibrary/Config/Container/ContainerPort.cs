namespace VyosConfigLibrary.Config.Container;

public class ContainerPort : BaseVyosConfigNode<ContainerPort>
{
    public int? Source { get; set; }
    public int? Destination { get; set; }
    public ContainerPortProtocol? Protocol { get; set; }
}