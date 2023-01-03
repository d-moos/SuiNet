using Shouldly;

namespace Naami.SuiNet.Tests.Apis.CoinRead;

public class GetBalancesSpecifications : BaseCoinReadApiSpecifications
{
    [Test]
    public async Task GetBalance_Returns_Values()
    {
        var response = await CoinReadApi.GetBalances(Constants.SuiFaucetWalletAddress);
        response.Length.ShouldBeGreaterThan(0);
    }
    
    [Test]
    public async Task GetBalance_Returns_Values_With_Limited_Type()
    {
        var response = await CoinReadApi.GetBalances(Constants.SuiFaucetWalletAddress, "0x2::sui::SUI");
        response.Length.ShouldBeGreaterThan(0);
    }
}