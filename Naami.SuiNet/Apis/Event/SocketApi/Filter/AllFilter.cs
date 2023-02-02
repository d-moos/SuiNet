using System.Runtime.Serialization;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record AllFilter([property: DataMember(Name = "All")]ISuiEventFilter[] All) : ISuiEventFilter;