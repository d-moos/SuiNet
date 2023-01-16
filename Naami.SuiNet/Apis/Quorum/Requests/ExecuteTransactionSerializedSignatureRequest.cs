using System.Runtime.Serialization;

namespace Naami.SuiNet.Apis.Quorum.Requests;

[DataContract]
public record ExecuteTransactionSerializedSignatureRequest(
    [property: DataMember(Name = "tx_bytes")]
    string Base64TxBytes,
    [property: DataMember(Name = "signature")]
    string Base64Signature,
    [property: DataMember(Name = "request_type")]
    string RequestType
);