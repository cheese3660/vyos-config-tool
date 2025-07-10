namespace VyosConfigLibrary.Config.Interfaces.Components.OpenVpn;

public class KeepAlive
{
    public int? FailureCount { get; set; }
    public int? Interval { get; set; }
}