namespace Naami.SuiNet.Apis.Read.Transactions;

public record SuiGasCostSummary(ulong ComputationCost, ulong StorageCost, ulong StorageRebate);