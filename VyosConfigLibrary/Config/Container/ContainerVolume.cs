namespace VyosConfigLibrary.Config.Container;

public class ContainerVolume : BaseVyosConfigNode<ContainerVolume>
{
    public string? Source { get; set; }
    public string? Destination { get; set; }
    public ContainerVolumeMode? Mode { get; set; }
}