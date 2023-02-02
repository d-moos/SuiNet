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

    public Task<EventPage> GetEvents<TEventQuery>(TEventQuery query, bool isDescending = false)
        where TEventQuery : IEventQuery
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest<TEventQuery>>(method,
            new GetEventsRequest<TEventQuery>(query, isDescending));

    public Task<EventPage> GetEvents<TEventQuery>(TEventQuery query, uint limit, bool isDescending = false)
        where TEventQuery : IEventQuery
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest<TEventQuery>>(method,
            new GetEventsRequest<TEventQuery>(query, isDescending)
            {
                Limit = limit
            });

    public Task<EventPage> GetEvents<TEventQuery>(TEventQuery query, EventId cursor, bool isDescending = false)
        where TEventQuery : IEventQuery
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest<TEventQuery>>(method,
            new GetEventsRequest<TEventQuery>(query, isDescending)
            {
                Cursor = cursor
            });

    public Task<EventPage> GetEvents<TEventQuery>(TEventQuery query, EventId cursor, uint limit,
        bool isDescending = false)
        where TEventQuery : IEventQuery
        => _jsonRpcClient.SendAsync<EventPage, GetEventsRequest<TEventQuery>>(method,
            new GetEventsRequest<TEventQuery>(query, isDescending)
            {
                Limit = limit,
                Cursor = cursor
            });
}