using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.TransactionBuilder.Requests;

[DataContract]
public record TransferObjectRequest(
    [property: DataMember(Name = "signer")]
    SuiAddress Signer,
    [property: DataMember(Name = "object_id")]
    ObjectId ObjectId,
    [property: DataMember(Name = "gas_budget")]
    ulong GasBudget,
    [property: DataMember(Name = "recipient")]
    SuiAddress Recipient
)
{
    [property: DataMember(Name = "gas")] public ObjectId? Gas { get; set; }
}