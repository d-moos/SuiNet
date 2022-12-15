namespace Naami.SuiNet.JsonRpc;

public interface IJsonRpcClient
{
    public Task<TResult> SendAsync<TResult>(string method, object[] payload);

    public Task<Response<TResult>[]> SendBatchAsync<TResult>(BatchRequest request);
}

public class BatchRequest
{
    private Dictionary<string, Request> _requests = new();
    
    public void AddRequest(string method, object[] payload)
    {
        var id = Guid.NewGuid().ToString();
        var request = new Request(method, id)
        {
            Params = payload
        };

        _requests.Add(id, request);
    }

    public Request[] Requests => _requests.Values.ToArray();
}