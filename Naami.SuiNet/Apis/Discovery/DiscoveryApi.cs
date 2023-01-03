using Naami.SuiNet.JsonRpc;

namespace Naami.SuiNet.Apis.Discovery;

public record Info(string Version);

public class DiscoveryApi : IDiscoveryApi
{
    private readonly IJsonRpcClient _jsonRpcClient;

    public DiscoveryApi(IJsonRpcClient jsonRpcClient)
    {
        _jsonRpcClient = jsonRpcClient;
    }

    public async Task<string> GetVersion()
    {
        var discovery = await _jsonRpcClient.SendAsync<Discovery>("rpc.discover");
        return discovery.Info.Version;
    }
}