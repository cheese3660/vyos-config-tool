using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Macsec;

public class Security : BaseVyosConfigNode<Security>
{
    public SecurityCipher? Cipher { get; set; }
    public ConfigFlag? Encrypt { get; set; }
    public string? SourceInterface {get; set;}
    public SecurityStatic? Static {get; set;}
    public uint? ReplayWindow { get; set; }
}