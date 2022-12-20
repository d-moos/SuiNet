using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read;

public record SuiObject<T>(T Data, Owner Owner, TransactionDigest PreviousTransaction, ulong StorageRebate, SuiObjectRef Reference);