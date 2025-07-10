using System.Text.Json;
using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Config.Utilities;

/// <summary>
/// Represents an empty config node
/// Always ignore when writing null with this as a property
/// </summary>
[JsonConverter(typeof(ConfigFlagConverter))]
public class ConfigFlag : BaseVyosConfigNode<ConfigFlag>
{
    private static readonly ConfigFlag Instance = new();
    public static implicit operator bool(ConfigFlag? emptyConfigNode) => emptyConfigNode != null;
    
    public static implicit operator ConfigFlag?(bool value) => value ? Instance : null;
}

public class ConfigFlagConverter : JsonConverter<ConfigFlag>
{
    public override ConfigFlag? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var read = JsonSerializer.Deserialize<Dictionary<string,string>>(ref reader, options);
        return true;
    }

    public override void Write(Utf8JsonWriter writer, ConfigFlag value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteEndObject();
    }
}