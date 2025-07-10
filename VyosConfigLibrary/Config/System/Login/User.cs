using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.System.Login;

public class User : BaseVyosConfigNode<User>
{
    public string? FullName { get; set; }
    public Authentication? Authentication { get; set; }
    public ConfigFlag? Disable { get; set; }
}