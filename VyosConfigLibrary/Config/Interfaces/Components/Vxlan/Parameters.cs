using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Vxlan;

public class Parameters : BaseVyosConfigNode<Parameters>
{
    public ConfigFlag? External { get; set; }
    public ConfigFlag? NeighborSuppress { get; set; }
    public ConfigFlag? Nolearning { get; set; }
    public ConfigFlag? VniFilter { get; set; }
}