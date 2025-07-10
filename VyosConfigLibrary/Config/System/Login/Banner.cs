namespace VyosConfigLibrary.Config.System.Login;

public class Banner : BaseVyosConfigNode<Banner>
{
    public string? PreLogin { get; set; }
    public string? PostLogin { get; set; }
}