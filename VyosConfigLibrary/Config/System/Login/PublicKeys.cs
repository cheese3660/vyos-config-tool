namespace VyosConfigLibrary.Config.System.Login;

public class PublicKeys : BaseVyosConfigNode<PublicKeys>
{
    public string? Key { get; set; }
    public string? Type { get; set; }
    public string? Options { get; set; }
}