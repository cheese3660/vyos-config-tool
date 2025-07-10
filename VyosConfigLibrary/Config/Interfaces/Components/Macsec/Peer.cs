using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Macsec;

public class Peer : BaseVyosConfigNode<Peer>
{
    public string? Mac { get; set; }
    public string? Key { get; set; }
    public ConfigFlag? Disable { get; set; }
}