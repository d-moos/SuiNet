using Naami.SuiNet.Apis.Event.Filter;
using Naami.SuiNet.Apis.Event.Requests;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event;

public class EventApi : IEventApi
{
    private readonly IJsonRpcClient _jsonRpcClient;

    const string method = "sui_getEvents";

    public EventApi(IJsonRpcClient jsonRpcClient)
    {
        _jsonRpcClient = jsonRpcClient;
    }

    public Task<EventPage> GetEvents(bool isDescending = false)
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest>(method, new GetEventsRequest(isDescending));

    public Task<EventPage> GetEvents(uint limit, bool isDescending = false)
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest>(method, new GetEventsRequest(isDescending)
        {
            Limit = limit
        });

    public Task<EventPage> GetEvents(EventId cursor, bool isDescending = false)
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest>(method, new GetEventsRequest(isDescending)
        {
            Cursor = cursor
        });

    public Task<EventPage> GetEvents(EventId cursor, uint limit, bool isDescending = false)
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest>(method, new GetEventsRequest(isDescending)
        {
            Limit = limit,
            Cursor = cursor
        });

    public Task<EventPage> GetEvents<TEventFilter>(TEventFilter query, bool isDescending = false)
        where TEventFilter : IEventFilter
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest<TEventFilter>>(method,
            new GetEventsRequest<TEventFilter>(query, isDescending));

    public Task<EventPage> GetEvents<TEventFilter>(TEventFilter query, uint limit, bool isDescending = false)
        where TEventFilter : IEventFilter
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest<TEventFilter>>(method,
            new GetEventsRequest<TEventFilter>(query, isDescending)
            {
                Limit = limit
            });

    public Task<EventPage> GetEvents<TEventFilter>(TEventFilter query, EventId cursor, bool isDescending = false)
        where TEventFilter : IEventFilter
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest<TEventFilter>>(method,
            new GetEventsRequest<TEventFilter>(query, isDescending)
            {
                Cursor = cursor
            });

    public Task<EventPage> GetEvents<TEventFilter>(TEventFilter query, EventId cursor, uint limit,
        bool isDescending = false)
        where TEventFilter : IEventFilter
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest<TEventFilter>>(method,
            new GetEventsRequest<TEventFilter>(query, isDescending)
            {
                Limit = limit,
                Cursor = cursor
            });
}