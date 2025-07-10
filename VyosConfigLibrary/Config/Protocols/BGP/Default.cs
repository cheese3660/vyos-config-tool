namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Default : BaseVyosConfigNode<Default>
{
    public uint? LocalPref { get; set; }
}