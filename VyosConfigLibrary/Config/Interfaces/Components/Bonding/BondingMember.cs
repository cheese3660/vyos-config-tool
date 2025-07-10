using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Bonding;

public class BondingMember : BaseVyosConfigNode<BondingMember>
{
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Interface { get; set; }
}