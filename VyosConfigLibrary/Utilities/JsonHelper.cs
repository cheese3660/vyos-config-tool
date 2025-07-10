using System.Text.Json;
using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Utilities;

public static class JsonHelper
{
    public static JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.KebabCaseLower), 
            new IntStringConverter(), 
            new UintStringConverter(),
        }
    };
    
}