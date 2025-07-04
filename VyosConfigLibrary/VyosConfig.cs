using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VyosConfigLibrary;

public class VyosConfig : IVyosConfig
{
    [JsonPropertyName("interfaces")]
    public VyosInterfaces? Interfaces { get; set; }
    
    
    
    
    public void GenerateCommandList(StringBuilder commandListBuilder, string prefix)
    {
        Interfaces?.GenerateCommandList(commandListBuilder, prefix + " interfaces");
    }
    
    
    public string GenerateCommandList()
    {
        var builder = new StringBuilder();
        GenerateCommandList(builder, "set");
        return builder.ToString();
    }


    public string ToJson()
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
        return JsonSerializer.Serialize(this, options);
    }
}