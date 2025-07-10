namespace VyosConfigLibrary.Config.Protocols.BGP;

public class DistributeList : BaseVyosConfigNode<DistributeList>
{
    public int? Export { get; set; }
    public int? Import { get; set; }
}