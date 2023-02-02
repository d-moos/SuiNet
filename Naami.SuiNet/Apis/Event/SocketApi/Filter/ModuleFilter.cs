using System.Runtime.Serialization;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record ModuleFilter(
    [property: DataMember(Name = "Module")]
    string Module
) : ISuiEventFilter;