using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.TransactionBuilder.Requests;

[DataContract]
public record PublishRequest(
    [property: DataMember(Name = "signer")]
    SuiAddress Signer,
    [property: DataMember(Name = "compiled_modules")]
    string[] CompiledModules,
    [property: DataMember(Name = "gas_budget")]
    ulong GasBudget
)
{
    [property: DataMember(Name = "gas")] public ObjectId? Gas { get; set; }
}