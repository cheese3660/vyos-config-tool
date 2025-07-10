using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.System.Syslog;

public class Marker : BaseVyosConfigNode<Marker>
{
    public int? Interval { get; set; }
    public ConfigFlag? Disable { get; set; }
}