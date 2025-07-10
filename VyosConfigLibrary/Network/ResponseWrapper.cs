namespace VyosConfigLibrary.Network;

public class ResponseWrapper<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public VyosErrorInformation? Error {get; set;}
}