using Naami.SuiNet.Apis.CoinRead;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Extensions.ApiStreams;

public static class CoinReadApiExtensions
{
    public static async IAsyncEnumerable<Coin[]> GetCoinsStream(
        this ICoinReadApi coinReadApi,
        SuiAddress owner,
        SuiObjectType coinType,
        int pageSize = 100
    )
    {
        var page = await coinReadApi.GetCoins(owner, coinType, (uint)pageSize);

        yield return page.Data;

        while (page.NextCursor.HasValue)
        {
            page = await coinReadApi.GetCoins(owner, coinType, page.NextCursor!.Value, (uint)pageSize);
            yield return page.Data;
        }
    }
}