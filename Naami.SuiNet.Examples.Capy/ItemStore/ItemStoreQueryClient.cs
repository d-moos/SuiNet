using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.Examples.Capy.Capy.Types;
using Naami.SuiNet.Extensions.ApiStreams;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy;

public class ItemStoreQueryClient : IItemStoreQueries
{
    private readonly IReadApi _readApi;

    private readonly ObjectId _packageId;
    private readonly ObjectId _itemStoreId;

    private const string ItemModuleName = "capy_item";

    public ItemStoreQueryClient(IJsonRpcClient jsonRpcClient, ObjectId packageId, ObjectId itemStoreId)
    {
        _packageId = packageId;
        _itemStoreId = itemStoreId;
        _readApi = new ReadApi(jsonRpcClient);
    }
    
    public async Task<ItemStore> GetStore()
    {
        var response = await _readApi.GetObject<ItemStore>(_itemStoreId);
        return response.ExistsResult!.Data.Fields!;
    }

    public async Task<ListedItem[]> GetAvailableItems()
    {
        var itemKeys = new List<ObjectId>();
        
        await foreach (var dynamicFieldInfos in _readApi.GetDynamicFieldsStream(_itemStoreId))
        {
            var listedItems = dynamicFieldInfos
                .Where(x => x.ObjectType.Package == _packageId)
                .Where(x => x.ObjectType.Module == ItemModuleName)
                .Where(x => x.ObjectType.Struct == "ListedItem");

            itemKeys.AddRange(listedItems.Select(x => x.ObjectId));
        }
        
        var tasks = itemKeys
            .Select(id => _readApi.GetObject<ListedItem>(id))
            .ToArray();

        await Task.WhenAll(tasks);

        return tasks.Select(x => x.Result.ExistsResult!.Data.Fields!).ToArray();
    }
}