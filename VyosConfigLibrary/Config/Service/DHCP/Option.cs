using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Service.DHCP;

public class Option : BaseVyosConfigNode<Option>
{
    public string? SubnetMask { get; set; }
    public uint? TimeOffset { get; set; }
    public string? DefaultRouter { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? TimeServer { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? NameServers{ get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? DomainName { get; set; }
    public ConfigFlag? IpForwarding { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? NtpServers { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? WinsNameServers { get; set; }
    public string? ServerIdentifier { get; set; }
    public string? BootfileServer { get; set; }
    public string? TftpServerName { get; set; }
    public string? BootfileName { get; set; }
    public uint? BootSize { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? SmtpServer { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? PopServer { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? DomainSearch { get; set; }
    public string? StaticRoute { get; set; }
    public string? WpadUrl { get; set; }
    public int? Lease { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Range { get; set; }
    [JsonConverter(typeof(ArrayOrSingleConverter<string>))]
    public string[]? Exclude { get; set; }
    public string? Failover { get; set; }
    public string? VendorOption { get; set; }
}