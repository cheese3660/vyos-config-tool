using System.Text.Json;
using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Network;

public class RequestWrapper(VyosOperation[] data, string? key = null)
{
    public VyosOperation[] Data { get; set; } = data;

    public string? Key { get; set; } = key;

    public RequestWrapper(VyosOperation data, string? key = null) : this([data], key)
    {
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        List<KeyValuePair<string, string>> pairs = [];
        if (Key != null)
        {
            pairs.Add(new KeyValuePair<string, string>("key", Key));
        }

        if (data.Length == 1)
        {
            pairs.Add(new KeyValuePair<string, string>("data", JsonSerializer.Serialize(data[0], JsonHelper.SerializerOptions)));
        }
        else
        {
            pairs.Add(new KeyValuePair<string, string>("data", JsonSerializer.Serialize(data, JsonHelper.SerializerOptions)));
        }

        foreach (var (k, v) in pairs)
        {
            Console.WriteLine($"--form {k} = '{v}'");
        }
        return new FormUrlEncodedContent(pairs);
    }
}

