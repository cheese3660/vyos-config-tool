using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class NetworkBackdoor : BaseVyosConfigNode<NetworkBackdoor>
{
    public ConfigFlag? Backdoor { get; set; }
}