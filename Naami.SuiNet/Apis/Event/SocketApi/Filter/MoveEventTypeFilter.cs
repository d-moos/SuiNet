using System.Runtime.Serialization;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record MoveEventTypeFilter([property: DataMember(Name = "MoveEventType")]string MoveEventType) : ISuiEventFilter;