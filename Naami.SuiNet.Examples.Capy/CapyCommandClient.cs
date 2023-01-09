using Naami.SuiNet.Apis.Quorum;
using Naami.SuiNet.Apis.TransactionBuilder;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Signer;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy;

public class CapyCommandClient : ICapyCommands
{
    private const string ModuleName = "capy";

    private readonly Ed25519KeyPair _keyPair;
    private readonly SuiAddress _signerAddress;

    private readonly ObjectId _packageId;
    private readonly ObjectId _capyRegistryObjectId;

    private readonly ITransactionSigner _signer = new TransactionSigner();
    private readonly ITransactionBuilderApi _builderApi;
    private readonly IQuorumApi _quorumApi;

    public CapyCommandClient(IJsonRpcClient jsonRpcClient, Ed25519KeyPair keyPair, ObjectId packageId,
        ObjectId capyRegistryObjectId, SuiAddress signerAddress)
    {
        _builderApi = new TransactionBuilderApi(jsonRpcClient);
        _quorumApi = new QuorumApi(jsonRpcClient);

        _keyPair = keyPair;
        _packageId = packageId;
        _capyRegistryObjectId = capyRegistryObjectId;
        _signerAddress = signerAddress;
    }


    public Task AddItem(ObjectId capyId, ObjectId item)
        => ExecuteTransaction(
            "add_item",
            Array.Empty<SuiObjectType>(),
            new object[] { capyId, item }
        );

    public Task RemoveItem(ObjectId capyId, ObjectId item)
        => ExecuteTransaction(
            "remove_item",
            Array.Empty<SuiObjectType>(),
            new object[] { capyId, item }
        );

    public Task Breed(ObjectId capyOne, ObjectId capyTwo)
        => ExecuteTransaction(
            "breed",
            Array.Empty<SuiObjectType>(),
            new object[] { _capyRegistryObjectId, capyOne, capyTwo }
        );

    private async Task ExecuteTransaction(string function, SuiObjectType[] typeArgs, object[] callArgs)
    {
        var builder = await _builderApi.MoveCall(
            _signerAddress,
            _packageId,
            ModuleName,
            function,
            typeArgs,
            callArgs,
            10000
        );

        var signature = _signer.SignTransaction(
            new Intent(Scope.TransactionData),
            Convert.FromBase64String(builder.TxBytes),
            _keyPair
        );

        _ = await _quorumApi.ExecuteTransaction(
            builder.TxBytes,
            SignatureScheme.ED25519,
            signature,
            Convert.ToBase64String(_keyPair.RawPublicKey),
            ExecuteTransactionRequestType.WaitForEffectsCert
        );
    }
}