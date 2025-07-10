namespace VyosConfigLibrary.Config;

public interface IVyosConfig
{
    public IVyosConfig CloneConfig();
}
public interface IVyosConfigNode<out T> : IVyosConfig
{
    public T Clone();
}