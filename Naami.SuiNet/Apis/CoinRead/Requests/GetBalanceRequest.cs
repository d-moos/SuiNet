using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.CoinRead.Requests;

[DataContract]
public record GetBalanceRequest([property: DataMember(Name = "owner")] SuiAddress Owner)
{
    [DataMember(Name = "coin_type")] public SuiObjectType? CoinType { get; set; }
}