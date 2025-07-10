namespace VyosConfigLibrary.Config.Protocols.BGP;

public class DefaultOriginate : BaseVyosConfigNode<DefaultOriginate>
{
    public string? RouteMap { get; set; }
}