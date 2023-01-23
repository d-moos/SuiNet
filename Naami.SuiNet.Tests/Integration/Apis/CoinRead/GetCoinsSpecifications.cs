using Shouldly;

namespace Naami.SuiNet.Tests.Integration.Apis.CoinRead;

public class GetCoinsSpecifications : BaseCoinReadApiSpecification
{
    [Test]
    public async Task GetCoins_Owner_CoinType()
    {
        await MintTestingCoins(2);
        
        var page = await CoinReadApi.GetCoins(Utils.TestingSignerAddress, CoinType);
        page.Data.Length.ShouldBeGreaterThan(0);
    }
    
    [Test]
    public async Task GetCoins_Owner_CoinType_Size()
    {
        await MintTestingCoins(1);
        
        var page = await CoinReadApi.GetCoins(Utils.TestingSignerAddress, CoinType, 1);
        page.Data.Length.ShouldBe(1);
    }
    
    
    [Test]
    public async Task GetCoins_Owner_CoinType_Cursor()
    {
        var objectId = (await MintTestingCoins(1)).First();
        await MintTestingCoins(2);
        
        var page = await CoinReadApi.GetCoins(Utils.TestingSignerAddress, CoinType, objectId);
        page.Data.Length.ShouldBe(2);
    }
    
    [Test]
    public async Task GetCoins_Owner_CoinType_Cursor_Size()
    {
        var objectId = (await MintTestingCoins(1)).First();
        await MintTestingCoins(3);
        
        var page = await CoinReadApi.GetCoins(Utils.TestingSignerAddress, CoinType, objectId, 2);
        page.Data.Length.ShouldBe(2);
    }
} 