using Naami.SuiNet.Apis.Read.Requests;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Transactions;

namespace Naami.SuiNet.Apis.Read;

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

        return _jsonRpcClient.SendAsync<SuiObjectInfo[], GetObjectsOwnedByAddressRequest>(
            method,
            new GetObjectsOwnedByAddressRequest(suiAddress)
        );
    }

    public Task<SuiObjectInfo[]> GetObjectsOwnedByObject(ObjectId objectId)
    {
        const string method = "sui_getObjectsOwnedByObject";

        return _jsonRpcClient.SendAsync<SuiObjectInfo[], GetObjectsOwnedByObjectRequest>(
            method,
            new GetObjectsOwnedByObjectRequest(objectId)
        );
    }

    public Task<SuiObjectReadResult<SuiParsedData<T>>> GetObject<T>(ObjectId objectId)
    {
        const string method = "sui_getObject";

        return _jsonRpcClient.SendAsync<SuiObjectReadResult<SuiParsedData<T>>, GetObjectRequest>(method,
            new GetObjectRequest(objectId));
    }

    public async Task<SuiObjectReadResult<SuiParsedData<T>>[]> GetObjects<T>(params ObjectId[] objectId)
    {
        const string method = "sui_getObject";
        var response =
            await _jsonRpcClient.SendBatchAsync<SuiObjectReadResult<SuiParsedData<T>>, GetObjectRequest>(method,
                objectId.Select(x => new GetObjectRequest(x)).ToArray());

        return response;
    }

    public Task<SuiObjectReadResult<SuiParsedData>> GetObject(ObjectId objectId)
    {
        const string method = "sui_getObject";

        return _jsonRpcClient.SendAsync<SuiObjectReadResult<SuiParsedData>, GetObjectRequest>(method,
            new GetObjectRequest(objectId));
    }

    public Task<SuiObjectReadResult<SuiRawData>> GetRawObject(ObjectId objectId)
    {
        const string method = "sui_getRawObject";

        return _jsonRpcClient.SendAsync<SuiObjectReadResult<SuiRawData>, GetRawObjectRequest>(method,
            new GetRawObjectRequest(objectId));
    }

    public Task<ulong> GetTotalTransactionNumber()
    {
        const string method = "sui_getTotalTransactionNumber";

        return _jsonRpcClient.SendAsync<ulong>(method);
    }

    public Task<TransactionDigest[]> GetTransactionsInRange(SequenceNumber start, SequenceNumber end)
    {
        const string method = "sui_getTransactionsInRange";

        return _jsonRpcClient.SendAsync<TransactionDigest[], GetTransactionsInRangeRequest>(method,
            new GetTransactionsInRangeRequest(start, end));
    }

    public Task<SuiTransactionResponse> GetTransaction(TransactionDigest digest)
    {
        const string method = "sui_getTransaction";

        return _jsonRpcClient.SendAsync<SuiTransactionResponse, GetTransactionRequest>(method,
            new GetTransactionRequest(digest));
    }

    public async Task<SuiTransactionResponse[]> GetTransactions(params TransactionDigest[] digest)
    {
        const string method = "sui_getTransaction";
        var response =
            await _jsonRpcClient.SendBatchAsync<SuiTransactionResponse, GetTransactionRequest>(method,
                digest.Select(x => new GetTransactionRequest(x)).ToArray());

        return response;
    }

    public Task<DynamicFieldPage> GetDynamicFields(ObjectId parentObjectId, ObjectId? cursor = null, uint? limit = null)
    {
        const string method = "sui_getDynamicFields";

        return _jsonRpcClient.SendAsync<DynamicFieldPage, GetDynamicFieldsRequest>(method,
            new GetDynamicFieldsRequest(parentObjectId)
            {
                Cursor = cursor,
                Limit = limit
            });
    }

    public Task<SuiObjectReadResult<SuiParsedData<T>>> GetDynamicFieldObject<T>(ObjectId parentObjectId, byte[] field)
    {
        const string method = "sui_getDynamicFieldObject";

        var stringValues = field.Select(x => $"{x}u8");
        var v = $"vector[{string.Join(", ", stringValues)}]";


        return _jsonRpcClient.SendAsync<SuiObjectReadResult<SuiParsedData<T>>, GetDynamicFieldObjectRequest>(method,
            new GetDynamicFieldObjectRequest(parentObjectId, v)
        );
    }
}