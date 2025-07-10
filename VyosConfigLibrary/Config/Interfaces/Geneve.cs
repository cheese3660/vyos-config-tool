namespace VyosConfigLibrary.Config.Interfaces;

public class Geneve : BaseInterface<Geneve>
{
    public string? Remote { get; set; }
    public string? Vni { get; set; }
    public int? Port { get; set; }
}