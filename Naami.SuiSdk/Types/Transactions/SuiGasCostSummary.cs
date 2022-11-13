namespace Naami.SuiSdk.Types.Transactions;

public record SuiGasCostSummary(ulong ComputationCost, ulong StorageCost, ulong StorageRebate);