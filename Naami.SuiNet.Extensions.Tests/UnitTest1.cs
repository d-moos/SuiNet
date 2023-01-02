using Naami.SuiNet.Apis.CoinRead;
using Naami.SuiNet.Extensions.ApiStreams;
using Naami.SuiNet.JsonRpc;

namespace Naami.SuiNet.Extensions.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        var coinReadApi = new CoinReadApi(new JsonRpcClient("http://localhost:9000"));

        await foreach (var coins in coinReadApi.GetCoinsStream("0xc4173a804406a365e69dfb297d4eaaf002546ebd", "0x2::sui::SUI", 1))
        {
            var a = coins;
        }
        
        
        Assert.Pass();
    }
}