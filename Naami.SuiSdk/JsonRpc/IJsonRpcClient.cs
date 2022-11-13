namespace Naami.SuiSdk.JsonRpc;

public interface IJsonRpcClient
{
    public Task<TResult> SendAsync<TResult>(string method, object[] payload);
}