using Naami.SuiSdk.JsonRpc;
using Naami.SuiSdk.Types;
using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Apis;

public class TransactionBuilderApi : ITransactionBuilderApi
{
    private readonly IJsonRpcClient _jsonRpcClient;

    public TransactionBuilderApi(IJsonRpcClient jsonRpcClient)
    {
        _jsonRpcClient = jsonRpcClient;
    }

    public Task<TransactionBytes> TransferSui(
        SuiAddress signer,
        ObjectId suiObjectId,
        ulong gasBudget,
        SuiAddress recipient,
        ulong? amount = null
    )
    {
        const string method = "sui_transferSui";
        var parameters = new List<object>
        {
            signer,
            suiObjectId,
            gasBudget,
            recipient
        };

        if (amount.HasValue)
            parameters.Add(amount.Value);

        return _jsonRpcClient.SendAsync<TransactionBytes>(method, parameters.ToArray());
    }

    public Task<TransactionBytes> TransferObject(
        SuiAddress signer,
        ObjectId objectId,
        ulong gasBudget,
        SuiAddress recipient,
        ObjectId? gasObject = null
    )
    {
        const string method = "sui_transferObject";
        var parameters = gasObject.HasValue
            ? new object[]
            {
                signer,
                objectId,
                gasObject.Value,
                gasBudget,
                recipient
            }
            : new object[]
            {
                signer,
                objectId,
                gasBudget,
                recipient
            };

        return _jsonRpcClient.SendAsync<TransactionBytes>(method, parameters);
    }

    public Task<TransactionBytes> Pay(
        SuiAddress signer,
        ObjectId[] inputCoins,
        SuiAddress[] recipients,
        ulong[] amounts,
        ulong gasBudget,
        ObjectId? gasObject = null
    )
    {
        const string method = "sui_pay";
        var parameters = gasObject.HasValue
            ? new object[]
            {
                signer,
                inputCoins,
                recipients,
                amounts,
                gasObject.Value,
                gasBudget
            }
            : new object[]
            {
                signer,
                inputCoins,
                recipients,
                amounts,
                gasBudget
            };

        return _jsonRpcClient.SendAsync<TransactionBytes>(method, parameters);
    }

    public Task<TransactionBytes> PaySui(
        SuiAddress signer,
        ObjectId[] inputCoins,
        SuiAddress[] recipients,
        ulong[] amounts,
        ulong gasBudget
    )
    {
        const string method = "sui_paySui";
        return _jsonRpcClient.SendAsync<TransactionBytes>(method, new object[]
        {
            signer,
            inputCoins,
            recipients,
            amounts,
            gasBudget
        });
    }

    public Task<TransactionBytes> PayAllSui(
        SuiAddress signer,
        ObjectId[] inputCoins,
        SuiAddress recipient,
        ulong gasBudget
    )
    {
        const string method = "sui_payAllSui";
        return _jsonRpcClient.SendAsync<TransactionBytes>(method, new object[]
        {
            signer,
            inputCoins,
            recipient,
            gasBudget
        });
    }

    public Task<TransactionBytes> MoveCall(
        SuiAddress signer,
        ObjectId packageObjectId,
        string module,
        string function,
        SuiObjectType[] typeArgs,
        object[] callArgs,
        ulong gasBudget,
        ObjectId? gasObject = null
    )
    {
        const string method = "sui_moveCall";
        var parameters = gasObject.HasValue
            ? new object[]
            {
                signer,
                packageObjectId,
                module,
                function,
                typeArgs,
                callArgs,
                gasObject.Value,
                gasBudget
            }
            : new object[]
            {
                signer,
                packageObjectId,
                module,
                function,
                typeArgs,
                callArgs,
                gasBudget
            };

        return _jsonRpcClient.SendAsync<TransactionBytes>(method, parameters);
    }

    public Task<TransactionBytes> Publish(
        SuiAddress signer,
        byte[][] compiledModules,
        ulong gasBudget,
        ObjectId? gasObject = null
    )
    {
        const string method = "sui_publish";
        var parameters = gasObject.HasValue
            ? new object[]
            {
                signer,
                compiledModules,
                gasObject.Value,
                gasBudget
            }
            : new object[]
            {
                signer,
                compiledModules,
                gasBudget
            };

        return _jsonRpcClient.SendAsync<TransactionBytes>(method, parameters);
    }
}