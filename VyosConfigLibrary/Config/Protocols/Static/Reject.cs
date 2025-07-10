namespace VyosConfigLibrary.Config.Protocols.Static;

public class Reject : BaseVyosConfigNode<Reject>
{
    public int? Distance { get; set; }
    public string? Tag { get; set; }
}