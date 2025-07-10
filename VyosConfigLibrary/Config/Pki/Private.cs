using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Pki;

public class Private : BaseVyosConfigNode<Private>
{
    public ConfigFlag? PasswordProtected { get; set; }
    public string? Key { get; set; }
}