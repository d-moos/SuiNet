using Naami.SuiNet.Apis.Event;
using Naami.SuiNet.Apis.Event.Filter;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Extensions.ApiStreams;

public static class EventApiExtensions
{
    public static async IAsyncEnumerable<SuiEventEnvelope[]> GetEventStream(
        this IEventApi eventApi,
        int pageSize = 100,
        bool isDescending = false
    )
    {
        var page = await eventApi.GetEvents((uint)pageSize, isDescending);
        yield return page.Data;

        while (page.NextCursor != null)
        {
            page = await eventApi.GetEvents(page.NextCursor, (uint)pageSize, isDescending);
            yield return page.Data;
        }
    }
    
    public static async IAsyncEnumerable<SuiEventEnvelope[]> GetEventStream<TEventFilter>(
        this IEventApi eventApi,
        TEventFilter query,
        int pageSize = 100,
        bool isDescending = false
    ) where TEventFilter : IEventFilter
    {
        var page = await eventApi.GetEvents(query, (uint)pageSize, isDescending);
        yield return page.Data;

        while (page.NextCursor != null)
        {
            page = await eventApi.GetEvents(query, page.NextCursor, (uint)pageSize, isDescending);
            yield return page.Data;
        }
    }
    
    public static async IAsyncEnumerable<SuiEventEnvelope[]> GetEventStream(
        this IEventApi eventApi,
        EventId initialCursor,
        int pageSize = 100,
        bool isDescending = false
    )
    {
        var page = await eventApi.GetEvents((uint)pageSize, isDescending);
        yield return page.Data;

        while (page.NextCursor != null)
        {
            page = await eventApi.GetEvents(page.NextCursor, (uint)pageSize, isDescending);
            yield return page.Data;
        }
    }
    
    public static async IAsyncEnumerable<SuiEventEnvelope[]> GetEventStream<TEventFilter>(
        this IEventApi eventApi,
        TEventFilter query,
        EventId initialCursor,
        int pageSize = 100,
        bool isDescending = false
    ) where TEventFilter : IEventFilter
    {
        var page = await eventApi.GetEvents(query, initialCursor, (uint)pageSize, isDescending);
        yield return page.Data;

        while (page.NextCursor != null)
        {
            page = await eventApi.GetEvents(query, page.NextCursor, (uint)pageSize, isDescending);
            yield return page.Data;
        }
    }
}