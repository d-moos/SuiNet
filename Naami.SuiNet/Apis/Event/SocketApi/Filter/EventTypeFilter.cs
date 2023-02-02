using System.Runtime.Serialization;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record EventTypeFilter([property: DataMember(Name = "EventType")]Events.Event EventType) : ISuiEventFilter;