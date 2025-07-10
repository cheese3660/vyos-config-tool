using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Filter;

public class Filter
{
    public Dictionary<string, Rule.Rule>? Rule { get; set; }
    public ConfigFlag? DefaultLog { get; set; }
    public string? Description { get; set; }
    public Action? DefaultAction { get; set; }
    public string? DefaultJumpTarget { get; set; }
}