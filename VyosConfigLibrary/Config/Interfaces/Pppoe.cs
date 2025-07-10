using VyosConfigLibrary.Config.Interfaces.Components;
using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class Pppoe : BaseInterface<Pppoe>
{
    public string? AccessConcentrator { get; set; }
    public Authentication? Authentication { get; set; }
    public ConfigFlag? ConnectOnDemand { get; set; }
    public ConfigFlag? NoDefaultRoute { get; set; }
    public int? DefaultRouteDistance { get; set; }
    public int? Mru { get; set; }
    public int? IdleTimeout { get; set; }
    public int? Holdoff { get; set; }
    public string? LocalAddress { get; set; }
    public ConfigFlag? NoPeerDns { get; set; }
    public string? RemoteAddress { get; set; }
    public string? ServiceName { get; set; }
    public string? SourceInterface { get; set; }
}