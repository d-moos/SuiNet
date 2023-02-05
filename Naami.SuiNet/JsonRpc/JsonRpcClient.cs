using ServiceStack;
using ServiceStack.Text;

namespace Naami.SuiNet.JsonRpc;

public class JsonRpcClient : IJsonRpcClient
{
    private readonly string _baseUrl;

    public JsonRpcClient(string baseUrl)
    {
        JsConfig.IncludeTypeInfo = false;
        JsConfig.ExcludeTypeInfo = true;

        _baseUrl = baseUrl;
    }

    public async Task<TResult> SendAsync<TResult, TRequest>(string method, TRequest payload)
    {
        var id = Guid.NewGuid().ToString();

        var request = new Request<TRequest>(method, id)
        {
            Params = payload
        };

        var responseJson = await _baseUrl.PostJsonToUrlAsync(request);

        var response = responseJson.FromJson<Response<TResult>>();

        if (response.Error != null)
            throw new ResponseErrorException(response.Error.ToJson());

        if (response.Id != id)
            throw new InvalidIdException();

        return response.Result!;
    }

    public async Task<TResult> SendAsync<TResult>(string method)
    {
        var id = Guid.NewGuid().ToString();

        var request = new Request(method, id)
        {
            Params = null
        };

        var responseJson = await _baseUrl.PostJsonToUrlAsync(request);

        var response = responseJson.FromJson<Response<TResult>>();

        if (response.Error != null)
            throw new ResponseErrorException(response.Error.ToJson());

        if (response.Id != id)
            throw new InvalidIdException();

        return response.Result!;
    }

    public async Task<TResult[]> SendBatchAsync<TResult, TRequest>(string method, TRequest[] payloads)
    {
        var requests = payloads.Select(x => new Request<TRequest>(method, Guid.NewGuid().ToString())
        {
            Params = x
        }).ToArray();

        var responseJson = await _baseUrl.PostJsonToUrlAsync(requests);
        var response = responseJson.FromJson<Response<TResult>[]>();

        return response.Where(x => x.Error == null).Select(x => x.Result!).ToArray();
    }
}