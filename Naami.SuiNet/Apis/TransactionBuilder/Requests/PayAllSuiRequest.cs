using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.TransactionBuilder.Requests;

[DataContract]
public record PayAllSuiRequest(
    [property: DataMember(Name = "signer")]
    SuiAddress Signer,
    [property: DataMember(Name = "input_coins")]
    ObjectId[] InputCoins,
    [property: DataMember(Name = "recipient")]
    SuiAddress Recipient,
    [property: DataMember(Name = "gas_budget")]
    ulong GasBudget
);