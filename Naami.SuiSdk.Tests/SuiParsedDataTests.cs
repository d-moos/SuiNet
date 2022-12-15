using Naami.SuiNet.Apis;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types.Custom;

namespace Naami.SuiSdk.Tests;

public class SuiParsedDataTests
{
    [Test]
    public void Foo()
    {
        var type = "0x2::coin::Coin<0x51daa1c34887515c865353f1460feb713b4b7b88::pool::LSP<0xefc6a2da9621c0fb0580bf72e0e264e9fc0c47f8::eth::ETH, 0xefc6a2da9621c0fb0580bf72e0e264e9fc0c47f8::atom::ATOM>>";
        // <b<c,d<e,f,g,h>>>
        var t = new SuiObjectType(type);
        var d = t.Struct.GenericTypes.Length;
        var i = 0;
    }

    // LOL
    [Test]
    public async Task Test()
    {
        var client = new JsonRpcClient("https://fullnode.devnet.sui.io:443");
        var api = new ReadApi(client);

        var response = await api.GetTransaction("ELeOSITp0NW2Wl6j941vxyybXE6HkXEpwVZOJNRqDKY=");
        var foo = 2;
    }
}