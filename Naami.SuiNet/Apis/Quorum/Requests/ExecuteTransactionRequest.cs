using System.Runtime.Serialization;

namespace Naami.SuiNet.Apis.Quorum.Requests;

[DataContract]
public record ExecuteTransactionRequest(
    [property: DataMember(Name = "tx_bytes")]
    string Base64TxBytes,
    [property: DataMember(Name = "sig_scheme")]
    string SignatureScheme,
    [property: DataMember(Name = "signature")]
    string Base64Signature,
    [property: DataMember(Name = "pub_key")]
    string PublicKey,
    [property: DataMember(Name = "request_type")]
    string RequestType
);