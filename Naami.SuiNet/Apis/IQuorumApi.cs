using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis;

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