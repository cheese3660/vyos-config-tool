using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.Static;

public class NextHop : BaseVyosConfigNode<NextHop>
{
    public ConfigFlag? Disable { get; set; }
    public int? Distance { get; set; }
    public Bfd? Bfd { get; set; }
    public string? Segments { get; set; }
}