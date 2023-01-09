using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.Extensions.ApiStreams;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy;

public class CapyQueryClient : ICapyQueries
{
    private readonly IReadApi _readApi;

    private readonly ObjectId _packageId;
    private readonly ObjectId _itemStoreId;

    private const string CapyModuleName = "capy";
    private const string ItemModuleName = "capy_item";

    public CapyQueryClient(IJsonRpcClient jsonRpcClient, ObjectId packageId, ObjectId itemStoreId)
    {
        _packageId = packageId;
        _itemStoreId = itemStoreId;
        _readApi = new ReadApi(jsonRpcClient);
    }

    public async Task<Capy> GetCapy(ObjectId id)
    {
        var response = await _readApi.GetObject<Capy>(id);
        return response.ExistsResult.Data.Fields!;
    }

    public async Task<CapyItem[]> GetCapyItems(ObjectId capyObjectId)
    {
        var dynamicCapyObjectIds = new List<ObjectId>();

        await foreach (var dynamicFieldInfos in _readApi.GetDynamicFieldsStream(capyObjectId))
        {
            dynamicCapyObjectIds.AddRange(
                dynamicFieldInfos
                    .Where(x => x.ObjectType.Package == _packageId)
                    .Where(x => x.ObjectType.Module == ItemModuleName)
                    .Where(x => x.ObjectType.Struct == "CapyItem")
                    .Select(x => x.ObjectId)
            );
        }

        var tasks = dynamicCapyObjectIds
            .Select(id => _readApi.GetObject<CapyItem>(id))
            .ToArray();

        await Task.WhenAll(tasks);

        return tasks.Select(x => x.Result.ExistsResult!.Data.Fields!).ToArray();
    }

    public async Task<Capy[]> GetCapies(SuiAddress owner)
    {
        var ownedObjects = await _readApi.GetObjectsOwnedByAddress(owner);
        var capyObjectInfos = ownedObjects.Where(x => x.Type.Package == _packageId && x.Type.Module == CapyModuleName);

        var tasks = capyObjectInfos.Select(info => GetCapy(info.ObjectId));
        await Task.WhenAll(tasks);

        return tasks.Select(x => x.Result).ToArray();
    }
}