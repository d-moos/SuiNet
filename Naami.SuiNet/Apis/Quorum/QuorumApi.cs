using Naami.SuiNet.Apis.Quorum.Requests;
using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Quorum;

public class QuorumApi : IQuorumApi
{
    private readonly IJsonRpcClient _client;

    public QuorumApi(IJsonRpcClient client)
    {
        _client = client;
    }

    public Task<SuiExecuteTransactionResponse> ExecuteTransaction(
        string base64TxBytes,
        SignatureScheme signatureScheme,
        string base64Signature,
        string publicKey,
        ExecuteTransactionRequestType requestType
    )
    {
        var sigBytes = Convert.FromBase64String(base64Signature);
        var pubBytes = Convert.FromBase64String(publicKey);

        var merged = new List<byte> { (byte)signatureScheme };
        merged.AddRange(sigBytes);
        merged.AddRange(pubBytes);
        var serializedSignature = Convert.ToBase64String(merged.ToArray());

        return _client.SendAsync<
            SuiExecuteTransactionResponse,
            ExecuteTransactionSerializedSignatureRequest
        >(
            "sui_executeTransaction",
            new ExecuteTransactionSerializedSignatureRequest(
                base64TxBytes,
                serializedSignature,
                requestType.ToString()
            )
        );
    }
}