using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.TransactionBuilder.Requests;

[DataContract]
public record TransferSuiRequest(
    [property: DataMember(Name = "signer")]
    SuiAddress Signer,
    [property: DataMember(Name = "sui_object_id")]
    ObjectId SuiObjectId,
    [property: DataMember(Name = "gas_budget")]
    ulong GasBudget,
    [property: DataMember(Name = "recipient")]
    SuiAddress Recipient,
    [property: DataMember(Name = "amount")]
    ulong Amount
);