namespace Naami.SuiNet.Types.Transactions;

public record SuiGasCostSummary(ulong ComputationCost, ulong StorageCost, ulong StorageRebate);