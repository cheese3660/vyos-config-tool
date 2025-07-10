namespace VyosConfigLibrary.Config.Interfaces.Components;

public class PortMirror : BaseVyosConfigNode<PortMirror>
{
    public string? Ingress { get; set; }
    public string? Egress { get; set; }
}