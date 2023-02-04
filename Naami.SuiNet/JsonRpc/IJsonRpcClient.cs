using ServiceStack;

namespace Naami.SuiNet.JsonRpc;

public interface IJsonRpcClient
{
    public Task<TResult> SendAsync<TResult, TRequest>(string method, TRequest payload);
    public Task<TResult> SendAsync<TResult>(string method);

    public Task<TResult[]> SendBatchAsync<TResult, TRequest>(string method, TRequest[] payloads);
}
