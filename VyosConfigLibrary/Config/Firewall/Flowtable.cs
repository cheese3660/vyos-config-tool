namespace VyosConfigLibrary.Config.Firewall;

public class Flowtable : BaseVyosConfigNode<Flowtable>
{
    public string? Interface { get; set; }
    public string? Description { get; set; }
    public FlowtableOffload? Offload { get; set; }
}

public enum FlowtableOffload
{
    Hardware,
    Software,
}