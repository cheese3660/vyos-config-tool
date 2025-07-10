namespace VyosConfigLibrary.Config.Protocols.Static;

public class Bfd : BaseVyosConfigNode<Bfd>
{
    public string? Profile { get; set; }
    public MultiHop? MultiHop { get; set; }
}