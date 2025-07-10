namespace VyosConfigLibrary.Config.System.Login;

public class Login : BaseVyosConfigNode<Login>
{
    public Dictionary<string, User>? User { get; set; }
    // TODO: Radius
    // TODO TACACS+
    public Banner? Banner { get; set; }
    public int? MaxLoginSession { get; set; }
    public int? Timeout { get; set; }
}