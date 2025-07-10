using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Firewall.Rule;

public class Rule : BaseVyosConfigNode<Rule>
{
    public AddAddressToGroup? AddAddressToGroup { get; set; }
    public Action? Action { get; set; }
    public string? JumpTarget { get; set; }
    public int? Queue { get; set; }
    public QueueOptions? QueueOptions { get; set; }
    public ConfigFlag? Log { get; set; }
    public LogOptions? LogOptions { get; set; }
    public string? Description { get; set; }
    public ConfigFlag? Disable { get; set; }
    public ConnectionStatus? ConnectionStatus { get; set; }
    public int? ConnectionMark { get; set; }
    public string? ConntrackHelper { get; set; }
    public SourceDestination? Source { get; set; }
    public SourceDestination? Destination { get; set; }
    public string? Dscp { get; set; }
    public string? DscpExclude { get; set; }
    public Fragment? Fragment { get; set; }
    public Icmp? Icmp { get; set; }
    public Icmp? Icmpv6 { get; set; }
    public Interface? InboundInterface { get; set; }
    public Interface? OutboundInterface { get; set; }
    public Ipsec? Ipsec { get; set; }
    public Limit? Limit { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? PacketLength { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? PacketLengthExclude { get; set; }
    public PacketType? PacketType { get; set; }
    public string? Protocol { get; set; }
    public Tcp? Tcp { get; set; }
    public State? State { get; set; }
    public Time? Time { get; set; }
    public Ttl? Ttl { get; set; }
    public Ttl? HopLimit { get; set; }
    public Recent? Recent { get; set; }
    public Synproxy? Synproxy { get; set; }
    public Vlan? Vlan { get; set; }
    public string? EthernetType { get; set; }
    public string? OffloadTarget { get; set; }
}