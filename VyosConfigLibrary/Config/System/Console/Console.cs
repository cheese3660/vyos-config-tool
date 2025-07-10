namespace VyosConfigLibrary.Config.System.Console;

public class Console : BaseVyosConfigNode<Console>
{
    public Dictionary<string, Device>? Device { get; set; }
}