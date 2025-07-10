using VyosConfigLibrary.Config.Interfaces.Components;
using VyosConfigLibrary.Config.Interfaces.Components.Bridge;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class Bridge : BaseInterface<Bridge>
{
    
    public Dictionary<string, Vif>? Vif { get; set; }

    public BridgeMemberList? Member { get; set; }
    
    public int? Aging { get; set; }

    public int? MaxAge { get; set; }
    
    public Igmp? Igmp { get; set; }
    
    public ConfigFlag? Stp { get; set; }

    public int? ForwardingDelay { get; set; }

    public int? HelloTime { get; set; }
    
    public ConfigFlag? EnableVlan { get; set; }
    
    public BridgeProtocol? Protocol { get; set; }

    public PortMirror? Mirror;
}