using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Requests;

[DataContract]
public record GetObjectsOwnedByObjectRequest(
    [property: DataMember(Name = "object_id")]
    ObjectId ObjectId);