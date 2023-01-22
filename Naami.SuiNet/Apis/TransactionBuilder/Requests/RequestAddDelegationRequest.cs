using System.Runtime.Serialization;
using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.TransactionBuilder.Requests;

[DataContract]
public record RequestAddDelegationRequest(
    [property: DataMember(Name = "signer")] SuiAddress Signer,
    [property: DataMember(Name = "coins")] ObjectId[] Coins,
    [property: DataMember(Name = "amount")] ulong Amount,
    [property: DataMember(Name = "validator")] SuiAddress Validator,
    [property: DataMember(Name = "gas_budget")] ulong GasBudget
)
{
    [property: DataMember(Name = "gas_budget")]
    public ObjectId? GasObject { get; init; }
}