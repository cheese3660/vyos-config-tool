namespace VyosConfigLibrary.Config.Firewall.Group;

public class RemoteGroup : BaseVyosConfigNode<RemoteGroup>
{
    public string? Url { get; set; }
    public string? Description { get; set; }
}