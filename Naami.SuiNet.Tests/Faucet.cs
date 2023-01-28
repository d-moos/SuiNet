using ServiceStack;

namespace Naami.SuiNet.Tests;

public class Faucet
{
    [Test]
    public async Task RequestDevnetCoins()
    {
        var address = "0x72a234bbe890602bb4b1a4bcf4a80f61c7244f63";
        var body = "{\"FixedAmountRequest\":{\"recipient\":\"" + address +"\"}}";
        await "https://faucet.testnet.sui.io/gas".PostJsonToUrlAsync(body);
    }
}