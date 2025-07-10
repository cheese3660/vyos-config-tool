namespace VyosConfigLibrary.Config.Firewall.Rule;

public class ConnectionStatus : BaseVyosConfigNode<ConnectionStatus>
{
    public string? Nat { get; set; }
}