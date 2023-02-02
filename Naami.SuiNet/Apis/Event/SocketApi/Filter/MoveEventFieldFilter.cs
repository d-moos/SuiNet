using System.Runtime.Serialization;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record MoveEventFieldFilter([property: DataMember(Name = "MoveEventField")]MoveEventField MoveEventField) : ISuiEventFilter;