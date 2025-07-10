namespace VyosConfigLibrary.Config.Protocols.BGP;

public class NameList : BaseVyosConfigNode<NameList>
{
    public string? Export { get; set; }
    public string? Import { get; set; }
}