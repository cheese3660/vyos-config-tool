using VyosConfigLibrary.Config.Interfaces.Components.Vxlan;
using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class Vxlan : BaseInterface<Vxlan>
{
    public int? Vni { get; set; }
    public int? Port { get; set; }
    public string? SourceAddress { get; set; }
    public ConfigFlag? Gpe { get; set; }
    public Parameters? Parameters { get; set; }
    public string? Remote { get; set; }
    public string? SourceInterface { get; set; }
    public string? Group { get; set; }
    public Dictionary<string, VlanToVni>? VlanToVni { get; set; }
}