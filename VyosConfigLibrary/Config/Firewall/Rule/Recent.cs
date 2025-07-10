namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Recent : BaseVyosConfigNode<Recent>
{
    public int? Count { get; set; }
    public RecentTime? Time { get; set; }
}

public enum RecentTime
{
    Second,
    Minute,
    Hour
}