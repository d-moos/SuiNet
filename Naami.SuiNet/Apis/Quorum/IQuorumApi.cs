using Naami.SuiNet.Apis.Read;

namespace Naami.SuiNet.Apis.Quorum;

public interface IQuorumApi
{
    Task<SuiExecuteTransactionResponse> ExecuteTransaction(
        string base64TxBytes,
        SignatureScheme signatureScheme,
        string base64Signature,
        string publicKey,
        ExecuteTransactionRequestType requestType
    );
}