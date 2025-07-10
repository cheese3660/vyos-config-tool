using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Dhcp;

public abstract class BaseDhcpOptions<T> : BaseVyosConfigNode<T> where T : BaseVyosConfigNode<T>, new()
{
    public string? ClientId { get; set; }
    public string? HostName { get; set; }
    public string? VendorClassId { get; set; }
    public ConfigFlag? NoDefaultRoute { get; set; }
    public int? DefaultRouteDistance { get; set; }
    
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Reject { get; set; }

    public string? UserClass { get; set; }
}