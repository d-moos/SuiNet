using Naami.SuiNet.Types;

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
}