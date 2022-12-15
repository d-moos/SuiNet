using System.Runtime.Serialization;
using Naami.SuiNet.Apis;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiSdk.Tests;

public class ReadApiSpecifications
{
    [Test]
    public async Task Foo()
    {
        var readApi = new ReadApi(new JsonRpcClient("https://fullnode.devnet.sui.io:443"));
        var r= await readApi.GetParsedObject<LiquidityPool>("0x9c2fdaff8f22aea7bfff5af9aae0ca4dee0f0830");
        var b = 9;
    }
}


public class LiquidityPool
{
    public ulong X { get; set; }
    public ulong Y { get; set; }
    
    [DataMember(Name = "lsp_supply")]
    public SuiObjectField<Balance> LspSupply { get; set; }
}


public record Balance(ulong Value);