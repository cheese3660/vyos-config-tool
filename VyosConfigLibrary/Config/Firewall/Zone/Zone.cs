using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Zone;

public class Zone : BaseVyosConfigNode<Zone>
{
    public string? Interface { get; set; }
    public ConfigFlag? LocalZone { get; set; }
    public Action? DefaultAction { get; set; }
    public ConfigFlag? DefaultLog { get; set; }
    public string? Description { get; set; }
}