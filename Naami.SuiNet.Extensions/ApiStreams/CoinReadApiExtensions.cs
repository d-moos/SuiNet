using Naami.SuiNet.Apis.CoinRead;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Extensions.ApiStreams;

public static class CoinReadApiExtensions
{
    // we're currently unable to pass a pageSize without a reference cursor,
    // thus the first RPC call actually queries with max limit.
    // once the RPC supports initial limit queries we can simplify this extension method
    public static async IAsyncEnumerable<Coin[]> GetCoinsStream(
        this ICoinReadApi coinReadApi,
        SuiAddress owner,
        SuiObjectType coinType,
        int pageSize = 100
    )
    {
        var page = await coinReadApi.GetCoins(owner, coinType);
        
        yield return page.Data.Take(pageSize).ToArray();

        var nextCursor = page.Data.Length > pageSize ? page.Data[pageSize].CoinObjectId : page.NextCursor;

        while (nextCursor.HasValue)
        {
            page = await coinReadApi.GetCoins(owner, coinType, nextCursor!.Value, (uint)pageSize);
            yield return page.Data;

            nextCursor = page.NextCursor;
        }
    }
}