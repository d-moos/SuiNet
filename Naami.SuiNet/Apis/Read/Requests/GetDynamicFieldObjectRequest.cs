using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Requests;

[DataContract]
public record GetDynamicFieldObjectRequest(
    [property: DataMember(Name = "parent_object_id")]
    ObjectId ParentObjectId,
    [property: DataMember(Name = "name")] string Name
);