using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Custom;
using Naami.SuiNet.Types.Transactions;

namespace Naami.SuiNet.Apis;

public class ReadApi : IReadApi
{
    private readonly IJsonRpcClient _jsonRpcClient;

    public ReadApi(IJsonRpcClient jsonRpcClient)
    {
        _jsonRpcClient = jsonRpcClient;
    }

    public Task<SuiObjectInfo[]> GetObjectsOwnedByAddress(SuiAddress suiAddress)
    {
        const string method = "sui_getObjectsOwnedByAddress";

        return _jsonRpcClient.SendAsync<SuiObjectInfo[]>(method, new object[] { suiAddress });
    }

    public Task<SuiObjectInfo[]> GetObjectsOwnedByObject(ObjectId objectId)
    {
        const string method = "sui_getObjectsOwnedByObject";

        return _jsonRpcClient.SendAsync<SuiObjectInfo[]>(method, new object[] { objectId });
    }

    public Task<SuiObjectReadResult<SuiParsedData<T>>> GetParsedObject<T>(ObjectId objectId)
    {
        const string method = "sui_getObject";

        return _jsonRpcClient.SendAsync<SuiObjectReadResult<SuiParsedData<T>>>(method, new object[] { objectId });
    }

    public Task<SuiObjectReadResult<SuiParsedData>> GetParsedObject(ObjectId objectId)
    {
        const string method = "sui_getObject";

        return _jsonRpcClient.SendAsync<SuiObjectReadResult<SuiParsedData>>(method, new object[] { objectId });
    }

    public Task<SuiObjectReadResult<SuiRawData>> GetObject(ObjectId objectId)
    {
        const string method = "sui_getRawObject";

        return _jsonRpcClient.SendAsync<SuiObjectReadResult<SuiRawData>>(method, new object[] { objectId });
    }

    public Task<ulong> GetTotalTransactionNumber()
    {
        const string method = "sui_getTotalTransactionNumber";

        return _jsonRpcClient.SendAsync<ulong>(method, Array.Empty<object>());
    }

    public Task<TransactionDigest[]> GetTransactionsInRange(SequenceNumber start, SequenceNumber end)
    {
        const string method = "sui_getTransactionsInRange";

        return _jsonRpcClient.SendAsync<TransactionDigest[]>(method, new object[] { start, end });
    }

    public Task<SuiTransactionResponse> GetTransaction(TransactionDigest digest)
    {
        const string method = "sui_getTransaction";

        return _jsonRpcClient.SendAsync<SuiTransactionResponse>(method, new object[] { digest });
    }
}