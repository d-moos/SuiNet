using Naami.SuiNet.Apis.TransactionBuilder.Requests;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.TransactionBuilder;

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
        ulong amount
    )
    {
        const string method = "sui_transferSui";
        return _jsonRpcClient.SendAsync<TransactionBytes, TransferSuiRequest>(method,
            new TransferSuiRequest(signer, suiObjectId, gasBudget, recipient, amount));
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

        return _jsonRpcClient.SendAsync<TransactionBytes, TransferObjectRequest>(method, new TransferObjectRequest(
            signer,
            objectId,
            gasBudget,
            recipient
        )
        {
            Gas = gasObject
        });
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
        return _jsonRpcClient.SendAsync<TransactionBytes, PayRequest>(method,
            new PayRequest(signer, inputCoins, recipients, amounts, gasBudget)
            {
                Gas = gasObject
            });
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
        return _jsonRpcClient.SendAsync<TransactionBytes, PaySuiRequest>(method, new PaySuiRequest(
            signer,
            inputCoins,
            recipients,
            amounts,
            gasBudget
        ));
    }

    public Task<TransactionBytes> PayAllSui(
        SuiAddress signer,
        ObjectId[] inputCoins,
        SuiAddress recipient,
        ulong gasBudget
    )
    {
        const string method = "sui_payAllSui";
        return _jsonRpcClient.SendAsync<TransactionBytes, PayAllSuiRequest>(method, new PayAllSuiRequest(
            signer,
            inputCoins,
            recipient,
            gasBudget
        ));
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

        return _jsonRpcClient.SendAsync<TransactionBytes, MoveCallRequest>(method,
            new MoveCallRequest(signer, packageObjectId, module, function, typeArgs, callArgs, gasBudget)
            {
                Gas = gasObject
            });
    }

    public Task<TransactionBytes> Publish(
        SuiAddress signer,
        string[] compiledModules,
        ulong gasBudget,
        ObjectId? gasObject = null
    )
    {
        const string method = "sui_publish";
        return _jsonRpcClient.SendAsync<TransactionBytes, PublishRequest>(method,
            new PublishRequest(signer, compiledModules, gasBudget)
            {
                Gas = gasObject
            });
    }

    public Task<TransactionBytes> RequestAddDelegation(SuiAddress signer,
        ObjectId[] coins,
        SuiAddress validator,
        U64 gasBudget,
        U64? amount = null,
        ObjectId? gasObject = null)
    {
        const string method = "sui_requestAddDelegation";
        
        return _jsonRpcClient.SendAsync<TransactionBytes, RequestAddDelegationRequest>(method,
            new RequestAddDelegationRequest(signer, coins, validator, gasBudget)
            {
                Amount = amount,
                GasObject = gasObject
            });
    }

    public Task<TransactionBytes> RequestWithdrawDelegation(SuiAddress signer, ObjectId delegation, ObjectId stakedSui,
        U64 gasBudget,
        ObjectId? gasObject = null)
    {
        const string method = "sui_requestWithdrawDelegation";
        return _jsonRpcClient.SendAsync<TransactionBytes, RequestWithdrawDelegationRequest>(method,
            new RequestWithdrawDelegationRequest(signer, delegation, stakedSui, gasBudget)
            {
                GasObject = gasObject
            });
    }

    public Task<TransactionBytes> RequestSwitchDelegation(SuiAddress signer, ObjectId delegation, ObjectId stakedSui,
        SuiAddress newValidatorAddress,
        U64 gasBudget, ObjectId? gasObject = null)
    {
        const string method = "sui_requestSwitchDelegation";
        return _jsonRpcClient.SendAsync<TransactionBytes, RequestSwitchDelegationRequest>(method,
            new RequestSwitchDelegationRequest(signer, delegation, stakedSui, newValidatorAddress, gasBudget)
            {
                GasObject = gasObject
            });
    }
}