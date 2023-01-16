using Naami.SuiNet.Apis.CoinRead;
using Naami.SuiNet.Apis.Quorum;
using Naami.SuiNet.Apis.TransactionBuilder;
using Naami.SuiNet.Signer;
using Naami.SuiNet.Types;
using Naami.SuiSdk.Tests;

namespace Naami.SuiNet.Tests.Integration.Apis.CoinRead;

public class BaseCoinReadApiSpecification
{
    protected readonly ITransactionBuilderApi TransactionBuilderApi;
    protected readonly IQuorumApi QuorumApi;
    protected readonly ITransactionSigner Signer;
    protected readonly ICoinReadApi CoinReadApi;

    protected SuiObjectType CoinType;
    protected ObjectId TreasuryCapObjectId;
    protected ObjectId SuiNetCoinObjectId;

    public BaseCoinReadApiSpecification()
    {
        TransactionBuilderApi = new TransactionBuilderApi(Utils.JsonRpcClient.Value);
        QuorumApi = new QuorumApi(Utils.JsonRpcClient.Value);
        CoinReadApi = new CoinReadApi(Utils.JsonRpcClient.Value);
        Signer = new TransactionSigner();
    }

    [SetUp]
    public async Task BeforeEach()
    {
        await DeploySuiNetTestingCoin();
    }

    private async Task DeploySuiNetTestingCoin()
    {
        var byteCode = new[]
        {
            "oRzrCwYAAAAKAQAMAgweAyoiBEwIBVRUB6gBmgEIwgI8Bv4CQQq/AwUMxAMoAAABAQICAgMCBAIFAAYCAAQHAgACCgwBAAECCwwBAAEFDAcAAQ0HAQAAAAgAAQABDgEEAQACDwYHAQIDEAkBAQgEEQoLAAMDDQEBCAEDAgUDCAUMAggABwgBAAILAgEIAAsDAQgAAQgEAQsFAQkAAQgABwkAAgoCCgIKAgsFAQgEBwgBAgsCAQkACwMBCQABCwMBCAABCQABBggBAQUBCwIBCAACCQAFBnN1aW5ldAZvcHRpb24EY29pbgh0cmFuc2Zlcgp0eF9jb250ZXh0A3VybAZTVUlORVQJVHhDb250ZXh0BGluaXQLZHVtbXlfZmllbGQLVHJlYXN1cnlDYXAMQ29pbk1ldGFkYXRhA1VybAZPcHRpb24Ebm9uZQ9jcmVhdGVfY3VycmVuY3kMc2hhcmVfb2JqZWN0BnNlbmRlcgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEAAAAAAAAAAAAAAAAAAAAAAAAAAgoCBQRTTkVUCgIHBlN1aU5ldAoCLCtUZXN0aW5nIENvaW4gZm9yIFN1aU5ldCBJbnRlZ3JhdGlvbiBUZXN0aW5nAAIBCQEAAAAAAhILADECBwAHAQcCOAAKATgBDAMMAgsDOAILAgsBLhEEOAMCAA=="
        };

        var builderResponse = await TransactionBuilderApi.Publish(Utils.TestingSignerAddress, byteCode, 10000);
        var signature = Signer.SignTransaction(
            new Intent(Scope.TransactionData),
            Convert.FromBase64String(builderResponse.TxBytes),
            Utils.TestingKeyPair
        );

        var deployResponse = await QuorumApi.ExecuteTransaction(
            builderResponse.TxBytes,
            SignatureScheme.ED25519,
            signature,
            Convert.ToBase64String(Utils.TestingKeyPair.PublicKey),
            ExecuteTransactionRequestType.WaitForEffectsCert
        );

        var packageId =
            deployResponse.EffectsCert.Effects.Effects.Created
                .Single(x => x.Owner.Ownership == Ownership.Immutable)
                .Reference.ObjectId;

        TreasuryCapObjectId = deployResponse.EffectsCert.Effects.Effects.Created
            .Single(x => x.Owner.Ownership == Ownership.AddressOwner)
            .Reference.ObjectId;

        CoinType = new SuiObjectType($"{packageId}::suinet::SUINET");
    }

    protected async Task<ObjectId[]> MintTestingCoins(int objectAmount, string amount = "10000")
    {
        var objectIds = new List<ObjectId>();
        for (var i = 0; i < objectAmount; i++)
        {
            var builderResponse = await TransactionBuilderApi.MoveCall(
                Utils.TestingSignerAddress,
                "0x2",
                "coin",
                "mint_and_transfer",
                new[] { CoinType },
                new object[] { TreasuryCapObjectId, amount, Utils.TestingSignerAddress },
                10000
            );

            var signature = Signer.SignTransaction(
                new Intent(Scope.TransactionData),
                Convert.FromBase64String(builderResponse.TxBytes),
                Utils.TestingKeyPair
            );


            var response = await QuorumApi.ExecuteTransaction(
                builderResponse.TxBytes,
                SignatureScheme.ED25519,
                signature,
                Convert.ToBase64String(Utils.TestingKeyPair.PublicKey),
                ExecuteTransactionRequestType.WaitForEffectsCert
            );

            objectIds.Add(response.EffectsCert.Effects.Effects.Created[0].Reference.ObjectId);
        }

        return objectIds.ToArray();
    }
}