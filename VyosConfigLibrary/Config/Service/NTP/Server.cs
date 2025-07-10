using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Service.NTP;

public class Server : BaseVyosConfigNode<Server>
{
    public ConfigFlag? Noselect { get; set; }
    public ConfigFlag? Nts { get; set; }
    public ConfigFlag? Pool { get; set; }
    public ConfigFlag? Prefer { get; set; }
    public ConfigFlag? Ptp { get; set; }
    public ConfigFlag? Interleave { get; set; }
}