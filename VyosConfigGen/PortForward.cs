using System.Runtime.Serialization;
using YamlDotNet.Serialization;

namespace VyosConfigGen;

public class PortForward
{
    public int ExternalPort { get; set; }
    public int InternalPort { get; set; }
    public int Size { get; set; }
    public string ForwardTo { get; set; }
    public string Protocol { get; set; }
}