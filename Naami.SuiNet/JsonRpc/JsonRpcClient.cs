using ServiceStack;
using ServiceStack.Text;

namespace Naami.SuiNet.JsonRpc;

public class JsonRpcClient : IJsonRpcClient
{
    private readonly string _baseUrl;

    public JsonRpcClient(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public async Task<TResult> SendAsync<TResult, TRequest>(string method, TRequest payload)
    {
        using var jsConfig = JsConfig.BeginScope();
        jsConfig.ExcludeTypeInfo = true;
        jsConfig.IncludeNullValues = false;
        jsConfig.IncludeTypeInfo = false;
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
        using var jsConfig = JsConfig.BeginScope();
        jsConfig.ExcludeTypeInfo = true;
        jsConfig.IncludeNullValues = false;
        jsConfig.IncludeTypeInfo = false;
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

    public async Task<Response<TResult>[]> SendBatchAsync<TResult>(BatchRequest request)
    {
        var result = await _baseUrl.PostJsonToUrlAsync(request.Requests);
        
        throw new NotImplementedException();
    }
}