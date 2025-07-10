using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using VyosConfigLibrary.Config;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Network;

public class VyosClient : IDisposable
{
    public HttpClient HttpClient { get; }
    private string? ApiKey { get; }

    public VyosClient(Uri uri, string? apiKey = null, HttpClientHandler? handler = null)
    {
        HttpClient = new HttpClient(handler ?? new HttpClientHandler())
        {
            BaseAddress = uri,
        };
        HttpClient.DefaultRequestHeaders.Clear();
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        ApiKey = apiKey;
    }

    private async Task<T> DeserializeResponse<T>(HttpResponseMessage response, JsonSerializerOptions? options = null)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Could complete request, {response.StatusCode}");
        }
        var data = await response.Content.ReadAsStringAsync();
        var deserialized = JsonSerializer.Deserialize<ResponseWrapper<T>>(data, options ?? JsonHelper.SerializerOptions);
        if (deserialized == null)
        {
            throw new Exception($"Deserialization failed: {data}");
        }

        if (!deserialized.Success)
        {
            throw new VyosException(deserialized.Error!);
        }
        return deserialized.Data!;
    }

    private async Task AssertNonFailed(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Could complete request, {response.StatusCode}");
        }
        var data = await response.Content.ReadAsStringAsync();
        var deserialized = JsonSerializer.Deserialize<ResponseWrapper<object>>(data, JsonHelper.SerializerOptions);
        if (deserialized == null)
        {
            throw new Exception($"Deserialization failed: {data}");
        }

        if (!deserialized.Success)
        {
            throw new VyosException(deserialized.Error!);
        }
    }

    public async Task<VyosInformation> GetVyosInformationAsync()
    {
        var response = HttpClient.GetAsync("info").Result;
        return await DeserializeResponse<VyosInformation>(response);
    }

    public async Task<VyosConfig> RetrieveVyosConfigAsync()
    {
        var request = new RequestWrapper(new VyosOperation
        {
            Op = VyosOperationType.ShowConfig,
            Path = []
        }, ApiKey);
        
        // var response = await HttpClient.PostAsJsonAsync("retrieve", request, JsonHelper.SerializerOptions).ConfigureAwait(false);

        var response = await HttpClient.PostAsync("retrieve", request.ToFormUrlEncodedContent());
        
        return await DeserializeResponse<VyosConfig>(response);
    }

    public async Task<T> RetreiveAsync<T>(params string[] path)
    {
        var options = new JsonSerializerOptions(JsonHelper.SerializerOptions);
        if (typeof(T).IsArray)
        {
            if (!typeof(T).GetElementType()!.IsConfigNode())
            {
                throw new Exception("You can only retrieve types that are config nodes.");
            }
            options.Converters.Add((JsonConverter)Activator.CreateInstance(typeof(ArrayOrSingleConverter<>).MakeGenericType(typeof(T).GetElementType()!))!);
        }
        else
        {
            if (!typeof(T).IsConfigNode())
            {
                throw new Exception("You can only retrieve types that are config nodes. or arrays of them");
            }
        }
        var request = new RequestWrapper(new VyosOperation
        {
            Op = VyosOperationType.ShowConfig,
            Path = path
        }, ApiKey);
        
        var response = await HttpClient.PostAsync("retrieve", request.ToFormUrlEncodedContent());
        
        return await DeserializeResponse<T>(response, options);
    }
    
    
    private List<VyosOperation> _operations = [];
    private bool _isQueuingOperations = false;

    public void BeginQueuingConfigureOperations()
    {
        if (_isQueuingOperations) {
            throw new InvalidOperationException("Already queuing operations");
        }
        _isQueuingOperations = true;
    }
    
    public async Task FlushConfigureOperationQueueAsync(bool stopQueuing = false)
    {
        if (!_isQueuingOperations)
        {
            throw new InvalidOperationException("Not queuing operations");
        }
        
        var request = new RequestWrapper(_operations.ToArray(), ApiKey);
        
        var response = await HttpClient.PostAsync("configure", request.ToFormUrlEncodedContent());

        await AssertNonFailed(response);
        
        _operations.Clear();
        
        if (stopQueuing)
        {
            _isQueuingOperations = false;
        }
    }
    
    

    public void Dispose()
    {
        HttpClient.Dispose();
    }
}