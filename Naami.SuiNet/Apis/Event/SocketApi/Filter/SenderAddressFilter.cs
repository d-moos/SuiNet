using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter;

[DataContract]
public record SenderAddressFilter([property: DataMember(Name = "SenderAddress")]SuiAddress SenderAddress) : ISuiEventFilter;