using Naami.SuiNet.Apis.Governance;
using Naami.SuiNet.Apis.Quorum;
using Naami.SuiNet.Apis.TransactionBuilder;
using Naami.SuiNet.Signer;
using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Tests.Integration.Staking;

public class DelegationSpecifications
{
    [Test]
    public async Task RequestAddDelegation()
    {
        const string coinObjectId = "0xb31550a25df6a926bc7991cddd14c0ce44e131a0";

        var governanceApi = new GovernanceApi(Utils.JsonRpcClient.Value);
        var builder = new TransactionBuilderApi(Utils.JsonRpcClient.Value);
        var quorumApi = new QuorumApi(Utils.JsonRpcClient.Value);

        var validators = await governanceApi.GetValidators();

        var tx = await builder.RequestAddDelegation(
            Utils.TestingSignerAddress,
            new[] { new ObjectId(coinObjectId) },
            validators.First().SuiAddress,
            10000,
            1000000
        );

        var signer = new TransactionSigner();
        var signature = signer.SignTransaction(
            new Intent(Scope.TransactionData),
            Convert.FromBase64String(tx.TxBytes),
            Utils.TestingKeyPair
        );

        await quorumApi.ExecuteTransactionSerializedSignature(
            tx.TxBytes,
            SignatureScheme.ED25519,
            signature,
            Convert.ToBase64String(Utils.TestingKeyPair.PublicKey),
            ExecuteTransactionRequestType.WaitForEffectsCert
        );
    }

    [Test]
    public async Task RequestSwitchDelegation()
    {
        var governanceApi = new GovernanceApi(Utils.JsonRpcClient.Value);
        var builder = new TransactionBuilderApi(Utils.JsonRpcClient.Value);
        var quorumApi = new QuorumApi(Utils.JsonRpcClient.Value);

        var validators = await governanceApi.GetValidators();

        var tx = await builder.RequestSwitchDelegation(
            Utils.TestingSignerAddress,
            new ObjectId("0x7a0d22cdb8104458a328a69fa3fe816b2ddd4404"),
            new ObjectId("0x33457162c3da91a31189e62339cf1fba7f246c7d"),
            validators.Last().SuiAddress,
            10000
        );

        var signer = new TransactionSigner();
        var signature = signer.SignTransaction(
            new Intent(Scope.TransactionData),
            Convert.FromBase64String(tx.TxBytes),
            Utils.TestingKeyPair
        );

        await quorumApi.ExecuteTransactionSerializedSignature(
            tx.TxBytes,
            SignatureScheme.ED25519,
            signature,
            Convert.ToBase64String(Utils.TestingKeyPair.PublicKey),
            ExecuteTransactionRequestType.WaitForEffectsCert
        );
    }
    
    [Test]
    public async Task RequestWithdrawDelegation()
    {
        const string coinObjectId = "0xb31550a25df6a926bc7991cddd14c0ce44e131a0";

        var builder = new TransactionBuilderApi(Utils.JsonRpcClient.Value);
        var quorumApi = new QuorumApi(Utils.JsonRpcClient.Value);

        var tx = await builder.RequestWithdrawDelegation(
            Utils.TestingSignerAddress,
            new ObjectId(""),
            new ObjectId("0x33457162c3da91a31189e62339cf1fba7f246c7d"),
            10000
        );

        var signer = new TransactionSigner();
        var signature = signer.SignTransaction(
            new Intent(Scope.TransactionData),
            Convert.FromBase64String(tx.TxBytes),
            Utils.TestingKeyPair
        );

        await quorumApi.ExecuteTransactionSerializedSignature(
            tx.TxBytes,
            SignatureScheme.ED25519,
            signature,
            Convert.ToBase64String(Utils.TestingKeyPair.PublicKey),
            ExecuteTransactionRequestType.WaitForEffectsCert
        );
    }
}