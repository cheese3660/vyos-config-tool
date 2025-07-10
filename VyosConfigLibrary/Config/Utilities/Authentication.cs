namespace VyosConfigLibrary.Config.Utilities;

public class Authentication : BaseVyosConfigNode<Authentication>
{
    public string? Password { get; set; }
    public string? Username { get; set; }
}