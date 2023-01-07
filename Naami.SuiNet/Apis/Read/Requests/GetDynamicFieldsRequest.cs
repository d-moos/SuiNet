using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Requests;

[DataContract]
public record GetDynamicFieldsRequest(
    [property: DataMember(Name = "parent_object_id")]
    ObjectId ParentObjectId
)
{
    [property: DataMember(Name = "cursor")]
    public ObjectId? Cursor { get; set; }

    [property: DataMember(Name = "limit")] 
    public uint? Limit { get; set; }
};