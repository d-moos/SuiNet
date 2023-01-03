using System.Runtime.Serialization;
using Naami.SuiNet.Apis.Event.Filter;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Requests;

[DataContract]
public record GetEventsRequest<TEventFilter>(
    [property: DataMember(Name = "query")] TEventFilter Query,
    [property: DataMember(Name = "descending_order")]
    bool DescendingOrder = false
) where TEventFilter : IEventFilter
{
    [DataMember(Name = "cursor")] public EventId? Cursor;
    [DataMember(Name = "limit")] public uint? Limit;
}

[DataContract]
public record GetEventsRequest(
    [property: DataMember(Name = "descending_order")]
    bool DescendingOrder = false
)
{
    [DataMember(Name = "query")] public string Query => "All";
    [DataMember(Name = "cursor")] public EventId? Cursor;
    [DataMember(Name = "limit")] public uint? Limit;
}