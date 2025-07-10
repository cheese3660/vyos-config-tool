using VyosConfigLibrary.Config.Firewall.Rule;

namespace VyosConfigLibrary.Config.Nat.Nat44;

public class Rule : BaseVyosConfigNode<Rule>
{
    public Interface? OutboundInterface { get; set; }
    public Interface? InboundInterface { get; set; }
    public Protocol? Protocol { get; set; }
    public SourceDestination? Source { get; set; }
    public SourceDestination? Destination { get; set; }
    public SourceDestination? Translation { get; set; }
    public SourceDestination? Redirect { get; set; }
    public SourceDestination? Exclude { get; set; }
    public string? Description { get; set; }
    // TODO: Load balance
}