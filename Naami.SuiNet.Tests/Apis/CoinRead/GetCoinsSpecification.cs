using System.Reflection.Metadata;
using Shouldly;

namespace Naami.SuiNet.Tests.Apis.CoinRead;

public class CoinReadApiSpecifications : BaseCoinReadApiSpecifications
{
    [Test]
    public async Task GetCoins_Returns_Values()
    {
        var result = await CoinReadApi.GetCoins(Constants.SuiFaucetWalletAddress, "0x2::sui::SUI");
        result.Data.Length.ShouldBeGreaterThan(0);
    }
    
    [Test]
    public async Task GetCoins_Returns_Given_Values_Amount()
    {
        var result = await CoinReadApi.GetCoins(Constants.SuiFaucetWalletAddress, "0x2::sui::SUI", 1);
        result.Data.Length.ShouldBe(1);
    }
}