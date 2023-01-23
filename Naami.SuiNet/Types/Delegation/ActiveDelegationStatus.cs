using System.Runtime.Serialization;
using Naami.SuiNet.SuiTypes;

namespace Naami.SuiNet.Types.Delegation;

[DataContract]
public record ActiveDelegationStatus(
    [property: DataMember(Name = "id")] Uid Id,
    [property: DataMember(Name = "staked_sui_id")]
    ObjectId StakedSuiId,
    [property: DataMember(Name = "pool_tokens")]
    SuiTypes.Balance PoolTokens,
    [property: DataMember(Name = "principal_sui_amount")]
    ulong PrincipalSuiAmount
);