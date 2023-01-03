namespace Naami.SuiNet.Types;

public record SuiObject<T>(T Data, Owner Owner, TransactionDigest PreviousTransaction, ulong StorageRebate, SuiObjectRef Reference);