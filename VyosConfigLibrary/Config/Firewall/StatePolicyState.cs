using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall;

public class StatePolicyState : BaseVyosConfigNode<StatePolicyState>
{
    public Action? Action { get; set; }
    public ConfigFlag? Log { get; set; }
    public LogLevel? LogLevel { get; set; }
}