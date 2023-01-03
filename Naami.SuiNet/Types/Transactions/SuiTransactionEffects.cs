using Naami.SuiNet.Types.Events;

namespace Naami.SuiNet.Types.Transactions;

public record SuiTransactionEffects(
    SuiExecutionStatus Status,
    SuiGasCostSummary GasUsed,
    TransactionDigest TransactionDigest,
    OwnedObjectRef GasObject
)
{
    public SuiObjectRef[] SharedObjects { get; set; } = Array.Empty<SuiObjectRef>();
    public SuiObjectRef[] Deleted { get; set; } = Array.Empty<SuiObjectRef>();
    public SuiObjectRef[] Wrapped { get; set; } = Array.Empty<SuiObjectRef>();
    
    public OwnedObjectRef[] Created { get; set; } = Array.Empty<OwnedObjectRef>();
    public OwnedObjectRef[] Mutated { get; set; } = Array.Empty<OwnedObjectRef>();
    public OwnedObjectRef[] Unwrapped { get; set; } = Array.Empty<OwnedObjectRef>();

    public SuiEvent[] Events { get; set; } = Array.Empty<SuiEvent>();
    
    public TransactionDigest[] Dependencies { get; set; } = Array.Empty<TransactionDigest>();
}