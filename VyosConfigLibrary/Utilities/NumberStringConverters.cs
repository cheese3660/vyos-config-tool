using System.Text.Json;
using System.Text.Json.Serialization;

namespace VyosConfigLibrary.Utilities;

public class IntStringConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return int.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value!.ToString());
    }
}

public class UintStringConverter : JsonConverter<uint>
{
    public override uint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return uint.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, uint value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value!.ToString());
    }
}

public class FloatStringConverter : JsonConverter<float>
{
    public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return float.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value:F3}");
    }
}