using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class Parameters : BaseVyosConfigNode<Parameters>
{
    public ConfigFlag? NetworkImportCheck { get; set; }
    public ConfigFlag? AllowMartianNexthop { get; set; }
    public string? RouterId { get; set; }
    public ConfigFlag? NoHardAdministrativeReset { get; set; }
    public ConfigFlag? LogNeighborChanges { get; set; }
    public ConfigFlag? NoClientToClientReflection { get; set; }
    public ConfigFlag? NoFastExternalFailover { get; set; }
    [JsonPropertyName("no-ipv6-auto-ra")]
    public ConfigFlag? NoIpv6AutoRa { get; set; }
    public ConfigFlag? EbgpRequiresPolicy { get; set; }
    public LabeledUnicast? LabeledUnicast { get; set; }
    public AdministrativeDistance? Distance { get; set; }
    public Dampening? Dampening { get; set; }
    public ConfigFlag? AlwaysCompareMed { get; set; }
    public BestPath? Bestpath { get; set; }
    public Default? Default { get; set; }
    public ConfigFlag? DeterministicMed { get; set; }
    public int? ClusterId { get; set; }
    public Confederation? Confederation { get; set; }
}

public enum LabeledUnicast
{
    ExplicitNull,
    [JsonStringEnumMemberName("ipv4-explicit-null")]
    Ipv4ExplicitNull,
    [JsonStringEnumMemberName("ipv6-explicit-null")]
    Ipv6ExplicitNull,
}