using Shouldly;

namespace Naami.SuiNet.Tests.Integration.Apis.CoinRead;

public class GetCoinMetaDataSpecifications : BaseCoinReadApiSpecification
{
    [Test]
    public async Task GetCoinMetaData_CoinType()
    {
        var metadata = await CoinReadApi.GetCoinMetaData(CoinType);
        metadata.Decimals.ShouldBe<byte>(2);
        metadata.Symbol.ShouldBe("SNET");
        metadata.Name.ShouldBe("SuiNet");
        metadata.Description.ShouldBe("Testing Coin for SuiNet Integration Testing");
    }
}