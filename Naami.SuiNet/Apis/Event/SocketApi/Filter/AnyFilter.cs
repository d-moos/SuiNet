using System.Runtime.Serialization;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record AnyFilter([property: DataMember(Name = "Any")]ISuiEventFilter[] Any) : ISuiEventFilter;