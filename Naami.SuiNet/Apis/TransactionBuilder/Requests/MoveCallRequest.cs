using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.TransactionBuilder.Requests;

[DataContract]
public record MoveCallRequest(
    [property: DataMember(Name = "signer")]
    SuiAddress Signer,
    [property: DataMember(Name = "package_object_id")]
    ObjectId PackageObjectId,
    [property: DataMember(Name = "module")]
    string Module,
    [property: DataMember(Name = "function")]
    string Function,
    [property: DataMember(Name = "type_arguments")]
    SuiObjectType[] TypeArguments,
    [property: DataMember(Name = "arguments")]
    object[] Arguments,
    [property: DataMember(Name = "gas_budget")]
    ulong GasBudget
)
{
    // todo: execution_mode
    [property: DataMember(Name = "gas")] public ObjectId? Gas { get; set; }
}