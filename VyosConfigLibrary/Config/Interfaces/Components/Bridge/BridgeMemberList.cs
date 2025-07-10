using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Bridge;

public class BridgeMemberList : BaseVyosConfigNode<BridgeMemberList>
{
    public Dictionary<string, BridgeMemberList>? Interface { get; set; }
}