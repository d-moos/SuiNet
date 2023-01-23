using Naami.SuiNet.Examples.Capy.Capy;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy.Test;

public class CapyQueryClientSpecifications
{
    private readonly CapyQueryClient _capyQueryClient = new(
        // new JsonRpcClient("http://localhost:9000"),
        new JsonRpcClient("https://fullnode.devnet.sui.io"),
        "0x30136e80e16ac92ff33a0ac2d67c64dc129eb0bc"
    );

    [Test]
    public async Task GetCapies()
    {
        var r = await _capyQueryClient.GetCapies("0x72a234bbe890602bb4b1a4bcf4a80f61c7244f63");
        var i = 0;
    }

    [Test]
    public async Task StreamCapyBornEvents()
    {
        await foreach (var capyBornEvent in _capyQueryClient.StreamCapyBornEvents(new EventId(263542, 45)))
        {
            var i = 0;
        }
    }
}