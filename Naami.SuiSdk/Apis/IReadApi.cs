using Naami.SuiSdk.Types;
using Naami.SuiSdk.Types.Custom;
using Naami.SuiSdk.Types.Transactions;

namespace Naami.SuiSdk.Apis;

public interface IReadApi
{
    public Task<SuiObjectInfo[]> GetObjectsOwnedByAddress(SuiAddress suiAddress);
    public Task<SuiObjectInfo[]> GetObjectsOwnedByObject(ObjectId objectId);
    public Task<SuiObjectReadResult<SuiParsedData>> GetParsedObject(ObjectId objectId);
    public Task<SuiObjectReadResult<SuiRawData>> GetObject(ObjectId objectId);
    public Task<ulong> GetTotalTransactionNumber();
    public Task<TransactionDigest[]> GetTransactionsInRange(SequenceNumber start, SequenceNumber end);
    public Task<SuiTransactionResponse> GetTransaction(TransactionDigest digest);
}