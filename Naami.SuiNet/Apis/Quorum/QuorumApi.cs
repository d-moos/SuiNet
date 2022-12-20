﻿using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.JsonRpc;

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
    ) => _client.SendAsync<SuiExecuteTransactionResponse>("sui_executeTransaction", new[]
    {
        base64TxBytes,
        signatureScheme.ToString(),
        base64Signature,
        publicKey,
        requestType.ToString()
    });
}