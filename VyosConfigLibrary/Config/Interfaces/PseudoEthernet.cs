using VyosConfigLibrary.Config.Interfaces.Components;

namespace VyosConfigLibrary.Config.Interfaces;

public class PseudoEthernet : BaseInterface<PseudoEthernet>
{
    public string? SourceInterface { get; set; }
    public Dictionary<string, Vif>? Vif { get; set; }
    
}