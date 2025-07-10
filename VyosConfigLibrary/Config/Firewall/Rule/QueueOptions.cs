using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Rule;

public class QueueOptions : BaseVyosConfigNode<QueueOptions>
{
    public ConfigFlag? Bypass { get; set; }
    public ConfigFlag? Fanout { get; set; }
    
}