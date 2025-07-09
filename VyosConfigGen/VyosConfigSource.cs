using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace VyosConfigGen;

public class VyosConfigSource
{
    public string WanInterface { get; set; }
    public string LanInterface { get; set; }
    public string WanLocalAddr { get; set; }
    public string OutboundWanIp { get; set; }
    public List<NetworkDescription> Networks { get; set; } = [];
    public Wireguard Wireguard { get; set; }
    
    public static VyosConfigSource FromYaml(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .WithEnumNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        return deserializer.Deserialize<VyosConfigSource>(yaml);
    }
}