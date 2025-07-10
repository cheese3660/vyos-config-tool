using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.System.Syslog;

public class Format : BaseVyosConfigNode<Format>
{
    public ConfigFlag? IncludeTimezone { get; set; }
    public ConfigFlag? OctetCounted { get; set; }
}