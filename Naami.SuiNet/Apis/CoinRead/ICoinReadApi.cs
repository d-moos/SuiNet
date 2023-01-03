using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.CoinRead;

public interface ICoinReadApi
{
    public Task<CoinPage> GetCoins(SuiAddress owner, SuiObjectType coinType, ObjectId cursor, uint size);
    public Task<CoinPage> GetCoins(SuiAddress owner, SuiObjectType coinType, uint size);
    public Task<CoinPage> GetCoins(SuiAddress owner, SuiObjectType coinType, ObjectId cursor);
    public Task<CoinPage> GetCoins(SuiAddress owner, SuiObjectType coinType);

    public Task<Balance[]> GetBalances(SuiAddress owner, SuiObjectType coinType);
    public Task<Balance[]> GetBalances(SuiAddress owner);

    public Task<Supply> GetTotalSupply(SuiObjectType coinType);
    public Task<CoinMetadata> GetCoinMetaData(SuiObjectType coinType);
}