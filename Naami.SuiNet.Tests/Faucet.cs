using Naami.SuiNet.Tests.Integration;
using ServiceStack;

namespace Naami.SuiNet.Tests;

public class Faucet
{
    [Test]
    public async Task RequestDevnetCoins()
    {
        var address = Utils.TestingSignerAddress;
        var body = "{\"FixedAmountRequest\":{\"recipient\":\"" + address +"\"}}";
        await "https://faucet.devnet.sui.io/gas".PostJsonToUrlAsync(body);
    }
}