using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.CoinRead.Requests;

[DataContract]
public record GetCoinsRequest(
    [property: DataMember(Name = "owner")] SuiAddress Owner,
    [property: DataMember(Name = "coin_type")]
    string CoinType
)
{
    [DataMember(Name = "cursor")] public ObjectId? Cursor { get; set; }

    [DataMember(Name = "limit")] public uint? Limit { get; set; }
}