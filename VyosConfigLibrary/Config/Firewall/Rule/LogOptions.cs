namespace VyosConfigLibrary.Config.Firewall.Rule;

public class LogOptions : BaseVyosConfigNode<LogOptions>
{
    public LogLevel? Level { get; set; }
    public int? Group { get; set; }
    public int? SnapshotLength { get; set; }
    public int? QueueThreshold { get; set; }
}