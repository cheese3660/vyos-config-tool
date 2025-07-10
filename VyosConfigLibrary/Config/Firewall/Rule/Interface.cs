namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Interface : BaseVyosConfigNode<Interface>
{
    public string? Name { get; set; }
    public string? Group { get; set; }
}