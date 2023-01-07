using Shouldly;

namespace Naami.SuiNet.Tests.Integration.Apis.CoinRead;

public class GetTotalSupplySpecifications : BaseCoinReadApiSpecification
{
    [Test]
    public async Task GetTotalSupply_CoinType()
    {
        await MintTestingCoins(2, "10");

        var totalSupply = await CoinReadApi.GetTotalSupply(CoinType);
        totalSupply.Value.ShouldBe<ulong>(20);
    }
}