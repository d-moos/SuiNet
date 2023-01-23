using Naami.SuiNet.Types.Numerics;
using Shouldly;

namespace Naami.SuiNet.Tests.Integration.Apis.CoinRead;

public class GetBalancesSpecifications : BaseCoinReadApiSpecification
{
    [Test]
    public async Task GetBalances_Owner_CoinType()
    {
        await MintTestingCoins(2, "10");

        var balances = await CoinReadApi.GetBalances(Utils.TestingSignerAddress, CoinType);
        balances.Length.ShouldBe(1);

        balances[0].CoinObjectCount.ShouldBe<uint>(2);
        balances[0].TotalBalance.ShouldBe<U128>("20");
    }
}