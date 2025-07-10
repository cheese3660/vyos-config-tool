namespace VyosConfigLibrary.Config.Protocols.BGP;

public class AdministrativeDistance : BaseVyosConfigNode<AdministrativeDistance>
{
    public DistanceGlobal? Global { get; set; }
    public Dictionary<string, DistancePrefix>? Prefix { get; set; }
}

public class DistancePrefix : BaseVyosConfigNode<DistancePrefix>
{
    public int? Distance { get; set; }
}

public class DistanceGlobal : BaseVyosConfigNode<DistanceGlobal>
{
    public int? External { get; set; }
    public int? Internal { get; set; }
    public int? Local { get; set; }
}
