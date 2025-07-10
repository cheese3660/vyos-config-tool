using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.Protocols.BGP;

public class AddressFamilyInstance : BaseVyosConfigNode<AddressFamilyInstance>
{
    public AllowasIn? AllowasIn { get; set; }
    public ConfigFlag? AsOverride { get; set; }
    public AttributeUnchanged? AttributeUnchanged { get; set; }
    public uint? MaximumPrefix { get; set; }
    public ConfigFlag? NexthopSelf { get; set; }
    public ConfigFlag? RemovePrivateAs { get; set; }
    public SoftReconfiguration? SoftReconfiguration { get; set; }
    public int? Weight { get; set; }
    public DefaultOriginate? DefaultOriginate { get; set; }
    public string? UnsupressMap { get; set; }
    public DistributeList? DistributeList { get; set; }
    public NameList? PrefixList { get; set; }
    public NameList? RouteMap { get; set; }
    public NameList? FilterList { get; set; }
    public AddressFamilyInstanceCapability? Capability { get; set; }
    public ConfigFlag? RouteReflectorClient { get; set; }
}

public class AddressFamilyInstanceCapability : BaseVyosConfigNode<AddressFamilyInstanceCapability>
{
    public Orf? Orf { get; set; }
}

public enum Orf
{
    Receive,
    Send
}