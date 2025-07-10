namespace VyosConfigLibrary.Config.Container;

public class ContainerTmpfs : BaseVyosConfigNode<ContainerTmpfs>
{
    public string? Destination { get; set; }
    public int? Size { get; set; }
}