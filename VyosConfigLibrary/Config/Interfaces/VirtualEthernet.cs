using VyosConfigLibrary.Config.Interfaces.Components;
using VyosConfigLibrary.Config.Interfaces.Components.Ethernet;

namespace VyosConfigLibrary.Config.Interfaces;

public class VirtualEthernet : BaseInterface<VirtualEthernet>
{
    public Dictionary<string, Vif>? Vif { get; set; }
    public Dictionary<string, VifS>? VifS { get; set; }
}