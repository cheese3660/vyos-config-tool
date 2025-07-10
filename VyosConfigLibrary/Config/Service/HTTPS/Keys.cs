namespace VyosConfigLibrary.Config.Service.HTTPS;

public class Keys : BaseVyosConfigNode<Keys>
{
    public Dictionary<string, KeyValue>? Id { get; set; }
}