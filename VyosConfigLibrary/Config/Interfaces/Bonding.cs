using VyosConfigLibrary.Config.Interfaces.Components;
using VyosConfigLibrary.Config.Interfaces.Components.Bonding;
using VyosConfigLibrary.Config.Interfaces.Components.Bridge;
using VyosConfigLibrary.Config.Interfaces.Components.Dhcp;
using VyosConfigLibrary.Config.Interfaces.Components.Ip;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class Bonding : BaseInterface<Bonding>
{
    
    public BondingMode? Mode { get; set; }
    
    public int? MinLinks {get; set;}
    
    public LacpRate? LacpRate { get; set; }

    public string? SystemMac { get; set; }
    
    public BondingHashPolicy? HashPolicy { get; set; }
    
    public string? Primary {get; set;}
    
    public ArpMonitor? ArpMonitor { get; set; }

    public Dictionary<string, Vif>? Vif { get; set; }
}