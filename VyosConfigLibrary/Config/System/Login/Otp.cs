namespace VyosConfigLibrary.Config.System.Login;

public class Otp : BaseVyosConfigNode<Otp>
{
    public string? Key { get; set; }
    public int? RateLimit { get; set; }
    public int? RateTime { get; set; }
    public int? WindowSize { get; set; }
}