using Naami.SuiNet.Apis.Discovery;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Tests.Integration;
using Shouldly;

namespace Naami.SuiSdk.Tests.Apis.Discovery;

public class DiscoveryApiSpecifications
{
    [Test]
    public async Task Ensure_GetVersion_Works()
    {
        var api = new DiscoveryApi(Utils.JsonRpcClient.Value);
        var version = await api.GetVersion();
        
        version.ShouldNotBeNullOrEmpty();
    }
}