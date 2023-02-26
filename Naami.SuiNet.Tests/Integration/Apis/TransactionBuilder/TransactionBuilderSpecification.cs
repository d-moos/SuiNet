using System.Text;
using Naami.SuiNet.Apis.Quorum;
using Naami.SuiNet.Apis.TransactionBuilder;
using Naami.SuiNet.Signer;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Tests.Integration.Apis;

public class TransactionBuilderSpecification
{
    protected readonly ITransactionBuilderApi TransactionBuilderApi;
    protected readonly IQuorumApi QuorumApi;
    protected readonly ITransactionSigner Signer;

    public TransactionBuilderSpecification()
    {
        TransactionBuilderApi = new TransactionBuilderApi(Utils.JsonRpcClient.Value);
        QuorumApi = new QuorumApi(Utils.JsonRpcClient.Value);
        Signer = new TransactionSigner();
    }

    [Test]
    public async Task Foo()
    {
        var b = 0;
        var foo = await TransactionBuilderApi.PaySui(
            Utils.TestingSignerAddress,
            new[] { new ObjectId("0x1a8bc32aecd9b98d34605faa84481e9f465796a9") },
            new[] { Utils.TestingSignerAddress },
            new[] { (ulong)10 },
            10000);

        var signResult = Signer.SignTransaction(new Intent(Scope.TransactionData), Convert.FromBase64String(foo.TxBytes),
            Utils.TestingKeyPair);
        
        var executionResult = await QuorumApi.ExecuteTransaction(
            foo.TxBytes,
            Utils.TestingKeyPair.Scheme,
            signResult,
            Convert.ToBase64String(Utils.TestingKeyPair.PublicKey),
            ExecuteTransactionRequestType.WaitForEffectsCert
        );

        var i = 123;
    }
}