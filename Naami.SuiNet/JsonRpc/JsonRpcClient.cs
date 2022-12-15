using ServiceStack;

namespace Naami.SuiNet.JsonRpc;

public class JsonRpcClient : IJsonRpcClient
{
    private readonly string _baseUrl;

    public JsonRpcClient(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public async Task<TResult> SendAsync<TResult>(string method, object[] payload)
    {
        var id = Guid.NewGuid().ToString();

        var request = new Request(method, id)
        {
            Params = payload.Any() ? payload : null
        };
        var responseJson = await _baseUrl.PostJsonToUrlAsync(request);

        var response = responseJson.FromJson<Response<TResult>>();

        if (response.Error != null)
            throw new ResponseErrorException(response.Error.ToJson());

        if (response.Id != id)
            throw new InvalidIdException();

        return response.Result!;
    }

    public async Task<Response<TResult>[]> SendBatchAsync<TResult>(BatchRequest request)
    {
        var result = await _baseUrl.PostJsonToUrlAsync(request.Requests);
        
        throw new NotImplementedException();
    }
}