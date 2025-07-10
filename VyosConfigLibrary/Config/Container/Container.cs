namespace VyosConfigLibrary.Config.Container;

public class Container : BaseVyosConfigNode<Container>
{
    public Dictionary<string, ContainerInstance>? Name { get; set; }
    public Dictionary<string, ContainerNetwork>? Network { get; set; }
    public Dictionary<string, ContainerRegistry>? Registry { get; set; }
}