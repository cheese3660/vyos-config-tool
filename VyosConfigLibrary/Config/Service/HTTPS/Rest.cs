using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Service.HTTPS;

public class Rest : BaseVyosConfigNode<Rest>
{
    public ConfigFlag? Debug { get; set; }
    public ConfigFlag? Strict { get; set; }
    
}