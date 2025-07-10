namespace VyosConfigLibrary.Config.Protocols.BGP;

public class ListenRange : BaseVyosConfigNode<ListenRange>
{
    public string? PeerGroup { get; set; }
}