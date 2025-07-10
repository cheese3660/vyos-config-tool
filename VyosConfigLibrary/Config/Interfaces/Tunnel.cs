using VyosConfigLibrary.Config.Interfaces.Components.Tunnel;

namespace VyosConfigLibrary.Config.Interfaces;

public class Tunnel : BaseInterface<Tunnel>
{
    public string? Vrf { get; set; }
    public string? Encapsulation { get; set; }
    public string? SourceAddress { get; set; }
    public string? Remote { get; set; }
    public string? Address { get; set; }
    public Parameters? Parameters { get; set; }
}