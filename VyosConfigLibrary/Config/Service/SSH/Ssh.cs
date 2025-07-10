using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Service.SSH;

public class Ssh : BaseVyosConfigNode<Ssh>
{
    public int? Port { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? ListenAddress { get; set; }

    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Ciphers { get; set; }
    
    public ConfigFlag? DisablePasswordAuthentication { get; set; }
    public ConfigFlag? DisableHostValidation { get; set; }
    public string? Mac { get; set; }

    public int? ClientKeepaliveInterval { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? KeyExchange { get; set; }

    public LogLevel? Loglevel { get; set; }
    public string? Vrf { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? PubkeyAcceptedAlgorithm { get; set; }

    public string? TrustedUserCa { get; set; }
    
    public AccessControl? AccessControl { get; set; }
}