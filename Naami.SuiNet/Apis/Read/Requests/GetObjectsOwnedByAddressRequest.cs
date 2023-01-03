using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Requests;

[DataContract]
public record GetObjectsOwnedByAddressRequest(
    [property: DataMember(Name = "address")]
    SuiAddress Address
);