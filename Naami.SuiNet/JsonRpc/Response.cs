namespace Naami.SuiNet.JsonRpc;

public record Response<TResult>(string JsonRpc, string Id)
{
    public TResult? Result { get; set; }
    public object? Error { get; set; }
}