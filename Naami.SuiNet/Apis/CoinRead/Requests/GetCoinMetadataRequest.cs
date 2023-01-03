using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.CoinRead.Requests;

[DataContract]
public record GetCoinMetadataRequest([property: DataMember(Name = "coin_type")]
    SuiObjectType CoinType);