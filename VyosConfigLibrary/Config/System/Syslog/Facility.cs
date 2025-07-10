namespace VyosConfigLibrary.Config.System.Syslog;

public class Facility : BaseVyosConfigNode<Facility>
{
    public SeverityLevel? SeverityLevel { get; set; }
}