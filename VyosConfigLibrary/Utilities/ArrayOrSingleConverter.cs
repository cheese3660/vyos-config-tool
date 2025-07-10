using System.Text.Json;
using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Utilities;

public class ArrayOrSingleConverter<T> : JsonConverter<T[]>
{
    public override T[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType != JsonTokenType.StartArray
            ? [JsonSerializer.Deserialize<T>(ref reader, options)!]
            : JsonSerializer.Deserialize<T[]>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, T[] value, JsonSerializerOptions options)
    {
        if (value.Length == 1)
        {
            JsonSerializer.Serialize(writer, value[0], options);
        }
        else
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}