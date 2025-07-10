namespace VyosConfigLibrary.Config.Interfaces.Components.Ethernet;

public class VifS : BaseVyosConfigNode<VifS>
{
    public Dictionary<string, Vif> VifC { get; set; }
}