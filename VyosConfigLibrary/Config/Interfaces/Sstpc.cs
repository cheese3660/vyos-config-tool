using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces;

public class Sstpc : BaseInterface<Sstpc>
{
    public ConfigFlag? NoDefaultRoute { get; set; }
    public int? DefaultRouteDistance { get; set; }
    public ConfigFlag? NoPeerDns { get; set; }
    public string? Server { get; set; }
    
}