using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Transactions;

namespace Naami.SuiNet.Apis.Read;

public interface IReadApi
{
    public Task<SuiObjectInfo[]> GetObjectsOwnedByAddress(SuiAddress suiAddress);
    public Task<SuiObjectInfo[]> GetObjectsOwnedByObject(ObjectId objectId);
    public Task<SuiObjectReadResult<SuiParsedData<T>>> GetObject<T>(ObjectId objectId);
    public Task<SuiObjectReadResult<SuiParsedData>> GetObject(ObjectId objectId);
    public Task<SuiObjectReadResult<SuiRawData>> GetRawObject(ObjectId objectId);
    public Task<ulong> GetTotalTransactionNumber();
    public Task<TransactionDigest[]> GetTransactionsInRange(SequenceNumber start, SequenceNumber end);
    public Task<SuiTransactionResponse> GetTransaction(TransactionDigest digest);
    public Task<DynamicFieldPage> GetDynamicFields(ObjectId parentObjectId, ObjectId? cursor = null, uint? limit = null);
    public Task<SuiObjectReadResult<SuiParsedData<T>>> GetDynamicFieldObject<T>(ObjectId parentObjectId, byte[] field);
}