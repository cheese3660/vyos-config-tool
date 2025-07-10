using VyosConfigLibrary.Config.Interfaces.Components;
using VyosConfigLibrary.Config.Interfaces.Components.Ethernet;
using VyosConfigLibrary.Config.Interfaces.Components.Wireless;
using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class Wireless : BaseInterface<Wireless>
{
    public int? Channel { get; set; }
    public ConfigFlag? DisableBroadcastSsid { get; set; }
    public ConfigFlag? ExpungeFailingStations { get; set; }
    public ConfigFlag? IsolateStations { get; set; }
    public int? MaxStations { get; set; }
    public ConfigFlag? MgmtFrameProtection { get; set; }
    public ConfigFlag? EnableBfProtection { get; set; }
    public string? Mode { get; set; }
    public string? PhysicalDevice { get; set; }
    public int? ReduceTransmitPower { get; set; }
    public string? Ssid { get; set; }
    public WirelessType? WirelessType { get; set; }
    public ConfigFlag? PerClientThread { get; set; }
    public Capabilities? Capabilities { get; set; }
    public Dictionary<string, Vif>? Vif { get; set; }
    public Dictionary<string, VifS>? VifS { get; set; }
    // TODO: Security ><
}