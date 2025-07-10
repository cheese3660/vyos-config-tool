using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Wireless;

public class Capabilities : BaseVyosConfigNode<Capabilities>
{
    public ConfigFlag? RequireHt { get; set; }
    public ConfigFlag? RequireVht { get; set; }
    public ConfigFlag? RequireHe { get; set; }
    public HighThroughput? Ht { get; set; }
    public VeryHighThroughput? Vht { get; set; }
    public HighEfficiency? He { get; set; }
}