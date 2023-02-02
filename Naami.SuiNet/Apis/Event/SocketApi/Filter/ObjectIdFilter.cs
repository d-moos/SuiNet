using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record ObjectIdFilter([property: DataMember(Name = "ObjectId")]ObjectId ObjectId) : ISuiEventFilter;