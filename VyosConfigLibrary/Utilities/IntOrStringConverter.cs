using System.Text.Json;
using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Utilities;

public class IntOrStringConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetInt32().ToString();
        }
        else
        {
            return reader.GetString();
        }
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        if (int.TryParse(value, out int intValue))
        {
            writer.WriteNumberValue(intValue);
        }
        else
        {
            writer.WriteStringValue(value);
        }
    }
}