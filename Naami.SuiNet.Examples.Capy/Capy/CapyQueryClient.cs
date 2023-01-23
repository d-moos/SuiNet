using Naami.SuiNet.Apis.Event;
using Naami.SuiNet.Apis.Event.Filter;
using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.Examples.Capy.Capy.Events;
using Naami.SuiNet.Examples.Capy.Capy.Types;
using Naami.SuiNet.Extensions.ApiStreams;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;
using ServiceStack;

namespace Naami.SuiNet.Examples.Capy.Capy;

public class CapyQueryClient : ICapyQueries
{
    private readonly IReadApi _readApi;
    private readonly IEventApi _eventApi;

    private readonly ObjectId _packageId;

    private const string CapyModuleName = "capy";
    private const string ItemModuleName = "capy_item";

    public CapyQueryClient(IJsonRpcClient jsonRpcClient, ObjectId packageId)
    {
        _packageId = packageId;
        _readApi = new ReadApi(jsonRpcClient);
        _eventApi = new EventApi(jsonRpcClient);
    }

    public async Task<Capy.Types.Capy> GetCapy(ObjectId id)
    {
        var response = await _readApi.GetObject<Capy.Types.Capy>(id);
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

    public async Task<Capy.Types.Capy[]> GetCapies(SuiAddress owner)
    {
        var ownedObjects = await _readApi.GetObjectsOwnedByAddress(owner);
        var capyObjectInfos = ownedObjects.Where(x => x.Type.Package == _packageId && x.Type.Module == CapyModuleName);

        var tasks = capyObjectInfos.Select(info => GetCapy(info.ObjectId));
        await Task.WhenAll(tasks);

        return tasks.Select(x => x.Result).ToArray();
    }

    public async IAsyncEnumerable<CapyBorn> StreamCapyBornEvents(EventId? cursor = null)
    {
        var filter = new MoveEventEventFilter(new SuiObjectType($"{_packageId}::capy::CapyBorn"));
        await foreach (var suiEventEnvelopes in _eventApi.GetEventStream(filter, cursor))
        {
            foreach (var suiEvent in suiEventEnvelopes)
            {
                var moveEvent = suiEvent.Event.MoveEvent!;
                yield return moveEvent.Fields.FromObjectDictionary<CapyBorn>();
            }
        }
    }
}