using Naami.SuiNet.Apis.Read.Transactions;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read;

public interface IReadApi
{
    public Task<SuiObjectInfo[]> GetObjectsOwnedByAddress(SuiAddress suiAddress);
    public Task<SuiObjectInfo[]> GetObjectsOwnedByObject(ObjectId objectId);
    public Task<SuiObjectReadResult<SuiParsedData<T>>> GetParsedObject<T>(ObjectId objectId);
    public Task<SuiObjectReadResult<SuiParsedData>> GetParsedObject(ObjectId objectId);
    public Task<SuiObjectReadResult<SuiRawData>> GetObject(ObjectId objectId);
    public Task<ulong> GetTotalTransactionNumber();
    public Task<TransactionDigest[]> GetTransactionsInRange(SequenceNumber start, SequenceNumber end);
    public Task<SuiTransactionResponse> GetTransaction(TransactionDigest digest);
}