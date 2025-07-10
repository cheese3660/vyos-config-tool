namespace VyosConfigLibrary.Config.Service.HTTPS;

public class Api : BaseVyosConfigNode<Api>
{
    public Keys? Keys { get; set; }
    public Rest? Rest { get; set; }
    // TODO: GraphQl
}