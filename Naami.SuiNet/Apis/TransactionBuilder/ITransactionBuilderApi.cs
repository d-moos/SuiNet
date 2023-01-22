using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.TransactionBuilder;

public interface ITransactionBuilderApi
{
    public Task<TransactionBytes> TransferSui(
        SuiAddress signer,
        ObjectId suiObjectId,
        ulong gasBudget,
        SuiAddress recipient,
        ulong amount
    );

    public Task<TransactionBytes> TransferObject(
        SuiAddress signer,
        ObjectId objectId,
        ulong gasBudget,
        SuiAddress recipient,
        ObjectId? gasObject = null
    );

    public Task<TransactionBytes> Pay(
        SuiAddress signer,
        ObjectId[] inputCoins,
        SuiAddress[] recipients,
        ulong[] amounts,
        ulong gasBudget,
        ObjectId? gasObject = null
    );

    public Task<TransactionBytes> PaySui(
        SuiAddress signer,
        ObjectId[] inputCoins,
        SuiAddress[] recipients,
        ulong[] amounts,
        ulong gasBudget
    );

    public Task<TransactionBytes> PayAllSui(
        SuiAddress signer,
        ObjectId[] inputCoins,
        SuiAddress recipient,
        ulong gasBudget
    );

    public Task<TransactionBytes> MoveCall(
        SuiAddress signer,
        ObjectId packageObjectId,
        string module,
        string function,
        SuiObjectType[] typeArgs,
        object[] callArgs,
        ulong gasBudget,
        ObjectId? gasObject = null
    );

    public Task<TransactionBytes> Publish(
        SuiAddress signer,
        string[] compiledModules,
        ulong gasBudget,
        ObjectId? gasObject = null
    );

    public Task<TransactionBytes> RequestAddDelegation(
        SuiAddress signer,
        ObjectId[] coins,
        SuiAddress validator,
        U64 gasBudget,
        U64? amount = null,
        ObjectId? gasObject = null
    );

    public Task<TransactionBytes> RequestWithdrawDelegation(
        SuiAddress signer,
        ObjectId delegation,
        ObjectId stakedSui,
        U64 gasBudget,
        ObjectId? gasObject = null
    );

    public Task<TransactionBytes> RequestSwitchDelegation(
        SuiAddress signer,
        ObjectId delegation,
        ObjectId stakedSui,
        SuiAddress newValidatorAddress,
        U64 gasBudget,
        ObjectId? gasObject = null
    );
}