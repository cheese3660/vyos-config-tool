namespace VyosConfigLibrary.Config.Firewall.Group;

public class AddressGroup : BaseVyosConfigNode<AddressGroup>
{
    public string? Address { get; set; }
    public string? Description { get; set; }
}