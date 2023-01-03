using Naami.SuiNet.Apis.Event.Filter;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event;

public class EventApi : IEventApi
{
    private readonly IJsonRpcClient _jsonRpcClient;

    public EventApi(IJsonRpcClient jsonRpcClient)
    {
        _jsonRpcClient = jsonRpcClient;
    }

    public Task<EventPage> GetEvents<TEventFilter>(TEventFilter query, bool isDescending = false)
        where TEventFilter : IEventFilter
    {
        const string method = "sui_getEvents";

        return _jsonRpcClient.SendAsync<EventPage>(method, new object[]
        {
            query,
            null, null,
            isDescending
        });
    }

    public Task<EventPage> GetEvents<TEventFilter>(TEventFilter query, EventId cursor, uint limit,
        bool isDescending = false)
        where TEventFilter : IEventFilter
    {
        const string method = "sui_getEvents";

        return _jsonRpcClient.SendAsync<EventPage>(method, new object[]
        {
            query,
            cursor, limit,
            isDescending
        });
    }


    public Task<EventPage> GetEvents(EventId cursor, uint limit, bool isDescending = false)
    {
        const string method = "sui_getEvents";

        return _jsonRpcClient.SendAsync<EventPage>(method, new object[]
        {
            "All",
            cursor, limit,
            isDescending
        });
    }

    public Task<EventPage> GetEvents(bool isDescending = false)
    {
        const string method = "sui_getEvents";

        return _jsonRpcClient.SendAsync<EventPage>(method, new object[]
        {
            "All",
            null, null,
            isDescending
        });
    }
}