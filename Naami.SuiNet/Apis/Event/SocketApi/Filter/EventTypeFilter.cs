using System.Runtime.Serialization;
using Naami.SuiNet.Apis.Event.Query;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record EventTypeFilter([property: DataMember(Name = "EventType")]EventType EventType) : ISuiEventFilter;