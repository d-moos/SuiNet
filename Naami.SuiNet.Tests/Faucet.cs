using ServiceStack;

namespace Naami.SuiNet.Tests;

public class Faucet
{
    [Test]
    public async Task RequestDevnetCoins()
    {
        var address = "0x88c7746e63ff557ab4ef2f018514681dcf025356";
        var body = "{\"FixedAmountRequest\":{\"recipient\":\"" + address +"\"}}";
        await "https://faucet.devnet.sui.io/gas".PostJsonToUrlAsync(body);
    }
}