namespace VyosConfigLibrary.Config.Interfaces.Components.Vxlan;

public class VlanToVni : BaseVyosConfigNode<VlanToVni>
{
    public string? Vni { get; set; }
}