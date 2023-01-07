using Naami.SuiNet.Apis.Quorum;
using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.Apis.TransactionBuilder;
using Naami.SuiNet.Signer;
using Naami.SuiNet.Types;
using Naami.SuiSdk.Tests;

namespace Naami.SuiNet.Tests.Integration.Apis.Read;

public abstract class BaseReadApiSpecification
{
    protected IReadApi ReadApi;
    protected readonly ITransactionBuilderApi TransactionBuilderApi;
    protected readonly IQuorumApi QuorumApi;
    protected readonly ITransactionSigner Signer;
    protected ObjectId ObjectId;
    protected TransactionDigest TransactionDigest;
    
    public BaseReadApiSpecification()
    {
        ReadApi = new ReadApi(Utils.JsonRpcClient.Value);
        TransactionBuilderApi = new TransactionBuilderApi(Utils.JsonRpcClient.Value);
        QuorumApi = new QuorumApi(Utils.JsonRpcClient.Value);
        Signer = new TransactionSigner();
    }

    [SetUp]
    public async Task BeforeEach()
    {
        await DeployTestingObject();
    }

    private async Task DeployTestingObject()
    {
        var byteCode = new[]
        {
            "oRzrCwYAAAALAQAKAgoQAxocBDYEBToiB1x5CNUBKAb9AQcKhAIQDJQCKg2+AgIAAAEBAQIBAwEEAAUMAAAGDAAEBwIAAgoEAAAIAAEAAg0AAwABDgUBAgcMBA8GBwADAwgBAQgCBAQCAQcIAgABCAEBCAMCCgIIAAMHCAMJAAkBAQYIAgEFAgkABQZzdWluZXQUZHluYW1pY19vYmplY3RfZmllbGQGb2JqZWN0CHRyYW5zZmVyCnR4X2NvbnRleHQLQ2hpbGRPYmplY3QITXlPYmplY3QJVHhDb250ZXh0BGluaXQCaWQDVUlEA2ZvbwNiYXIDbmV3A2FkZAZzZW5kZXIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACCgIEA2ZvbwACAgkIAwsCAQICCQgDDAIAAAAAAhMKABEBMQISAQwBDQEPAAcACgARATF7EgA4AAsBCwAuEQM4AQIBAAA="
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
            Convert.ToBase64String(Utils.TestingKeyPair.RawPublicKey),
            ExecuteTransactionRequestType.WaitForEffectsCert
        );

        var createdEvents = deployResponse.EffectsCert!.Effects.Effects.Created;
        ObjectId = createdEvents.Single(x => x.Owner.AddressOwnership?.AddressOwner == Utils.TestingSignerAddress)
            .Reference.ObjectId;
        TransactionDigest = deployResponse.EffectsCert.Certificate.TransactionDigest;
    }
}