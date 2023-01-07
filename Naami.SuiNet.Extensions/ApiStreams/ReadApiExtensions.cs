using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Extensions.ApiStreams;

public static class ReadApiExtensions
{
    public static async IAsyncEnumerable<DynamicFieldInfo[]> GetDynamicFieldsStream(
        this IReadApi readApi,
        ObjectId parentObjectId,
        ObjectId? initialCursor,
        int pageSize = 100
    )
    {
        var page = await readApi.GetDynamicFields(parentObjectId, initialCursor, (uint)pageSize);
        yield return page.Data;
        
        while (page.NextCursor.HasValue)
        {
            page = await readApi.GetDynamicFields(parentObjectId, page.NextCursor!.Value, (uint)pageSize);
            yield return page.Data;
        }
    }
}