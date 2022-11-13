using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types;

public record SuiObject<T>(T Data, Owner Owner, TransactionDigest PreviousTransaction, ulong StorageRebate, SuiObjectRef Reference);