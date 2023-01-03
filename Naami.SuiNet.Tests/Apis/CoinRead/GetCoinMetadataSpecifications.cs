using Shouldly;

namespace Naami.SuiNet.Tests.Apis.CoinRead;

public class GetCoinMetadataSpecifications : BaseCoinReadApiSpecifications
{
    [Test]
    public async Task GetCoinMetadata_Returns_Values()
    {
        var response = await CoinReadApi.GetCoinMetaData("0x2::sui::SUI");
        ((int)response.Decimals).ShouldBeGreaterThan(0);
    }
}