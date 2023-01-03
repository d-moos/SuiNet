using Naami.SuiNet.Apis.Event.Filter;
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

    public Task<EventPage> GetEvents<TEventFilter>(
        TEventFilter query,
        bool isDescending = false
    ) where TEventFilter : IEventFilter;

    public Task<EventPage> GetEvents<TEventFilter>(
        TEventFilter query,
        uint limit,
        bool isDescending = false
    ) where TEventFilter : IEventFilter;

    public Task<EventPage> GetEvents<TEventFilter>(
        TEventFilter query,
        EventId cursor,
        bool isDescending = false
    ) where TEventFilter : IEventFilter;

    
    public Task<EventPage> GetEvents<TEventFilter>(
        TEventFilter query,
        EventId cursor,
        uint limit,
        bool isDescending = false
    ) where TEventFilter : IEventFilter;
}