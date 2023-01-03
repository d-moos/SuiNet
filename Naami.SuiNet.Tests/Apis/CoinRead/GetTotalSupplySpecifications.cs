namespace Naami.SuiNet.Tests.Apis.CoinRead;

public class GetTotalSupplySpecifications : BaseCoinReadApiSpecifications
{
    [Test]
    public async Task GetTotalSupply_Returns_Values()
    {
        var response = await CoinReadApi.GetTotalSupply("0x2::sui::SUI");
        Assert.That(response.Value > 0);
    }
}