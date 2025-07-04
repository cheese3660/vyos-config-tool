using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace VyosConfigGen;

public class NetworkDescription
{
    public string Name { get; set; }
    public string WanIp { get; set; }
    public int LanVlan { get; set; }
    public List<string> LanIps { get; set; }
    public string LanPrimaryHost { get; set; }
    public List<DhcpLease>? DhcpLeases { get; set; }
    public List<PortForward>? PortForwards { get; set; }
    public List<AllowFrom>? AllowFrom { get; set; }

}