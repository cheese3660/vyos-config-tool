using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class LocalAs : BaseVyosConfigNode<LocalAs>
{
    public NoPrepend? NoPrepend { get; set; }
}

public class NoPrepend : BaseVyosConfigNode<NoPrepend>
{
    public ConfigFlag? ReplaceAs { get; set; }
}