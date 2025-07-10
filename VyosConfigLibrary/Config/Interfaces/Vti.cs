using VyosConfigLibrary.Config.Interfaces.Components.Vxlan;
using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class Vti : BaseInterface<Vti>
{
    public ConfigFlag? DisableRouteAutoinstall { get; set; }
}