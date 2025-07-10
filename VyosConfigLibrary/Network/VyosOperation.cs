using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Network;

public class VyosOperation
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public VyosOperationType Op { get; set; }


    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? Path {get; set;}
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? File { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? String { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonPropertyName("confirm_time")]
    public int ConfirmTime { get; set; }
}