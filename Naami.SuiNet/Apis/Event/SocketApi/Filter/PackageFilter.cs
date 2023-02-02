using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record PackageFilter([property: DataMember(Name = "Package")]ObjectId Package) : ISuiEventFilter;