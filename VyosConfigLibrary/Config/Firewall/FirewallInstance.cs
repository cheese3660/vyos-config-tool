using VyosConfigLibrary.Config.Firewall.Filter;

namespace VyosConfigLibrary.Config.Firewall;

public class FirewallInstance : BaseVyosConfigNode<FirewallInstance>
{
    public FilterContainer? Forward { get; set; }
    public FilterContainer? Input { get; set; }
    public FilterContainer? Output { get; set; }
    public Dictionary<string, Filter.Filter>? Name { get; set; }
}