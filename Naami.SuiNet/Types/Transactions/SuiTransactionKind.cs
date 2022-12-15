using Naami.SuiNet.Types.Custom;
using ServiceStack;
using ServiceStack.Text;

namespace Naami.SuiNet.Types.Transactions;

// TODO: this needs some testing
public record SuiTransactionKind
{
    public SuiTransferObject? TransferObject { get; set; }
    public SuiPay? Pay { get; set; }
    public SuiPaySui? PaySui { get; set; }
    public SuiPayAllSui? PayAllSui { get; set; }
    public SuiMovePackage? Publish { get; set; }
    public SuiMoveCall? Call { get; set; }
    public TransferSui? TransferSui { get; set; }
    public ChangeEpoch? ChangeEpoch { get; set; }
}

public record SuiTransferObject(SuiAddress Recipient, SuiObjectRef ObjectRef);
public record SuiPay(SuiObjectRef[] Coins, SuiAddress[] Recipients, ulong[] Amounts);
public record SuiPaySui(SuiObjectRef[] Coins, SuiAddress[] Recipients, ulong[] Amounts);
public record SuiPayAllSui(SuiObjectRef[] Coins, SuiAddress Recipient);
public record SuiMovePackage(ObjectDictionary Disassembled);

public record SuiMoveCall(SuiObjectRef Package, string Module, string Function)
{
    public string[] TypeArguments { get; set; } = Array.Empty<string>();
    public JsonValue[] Arguments { get; set; } = Array.Empty<JsonValue>();
}

public record TransferSui(SuiAddress Recipient)
{
    public ulong? Amount { get; set; }
}

public record ChangeEpoch(EpochId Epoch, ulong StorageCharge, ulong ComputationCharge);