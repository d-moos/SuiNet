using Naami.SuiNet.Apis.Event.Query;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event;

public interface IEventApi
{
    public Task<EventPage> GetEvents(
        bool isDescending = false
    );
    
    public Task<EventPage> GetEvents(
        uint limit,
        bool isDescending = false
    );
    
    public Task<EventPage> GetEvents(
        EventId cursor,
        bool isDescending = false
    );

    public Task<EventPage> GetEvents(
        EventId cursor,
        uint limit,
        bool isDescending = false
    );

    public Task<EventPage> GetEvents<TEventQuery>(
        TEventQuery query,
        bool isDescending = false
    ) where TEventQuery : IEventQuery;

    public Task<EventPage> GetEvents<TEventQuery>(
        TEventQuery query,
        uint limit,
        bool isDescending = false
    ) where TEventQuery : IEventQuery;

    public Task<EventPage> GetEvents<TEventQuery>(
        TEventQuery query,
        EventId cursor,
        bool isDescending = false
    ) where TEventQuery : IEventQuery;

    
    public Task<EventPage> GetEvents<TEventQuery>(
        TEventQuery query,
        EventId cursor,
        uint limit,
        bool isDescending = false
    ) where TEventQuery : IEventQuery;
}