using Naami.SuiNet.Apis.Quorum;
using Naami.SuiNet.Apis.TransactionBuilder;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Signer;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy;

public class ItemStoreCommandClient : IItemStoreCommands
{
    private const string ModuleName = "capy_item";

    private readonly Ed25519KeyPair _keyPair;
    private readonly SuiAddress _signerAddress;

    private readonly ObjectId _packageId;
    private readonly ObjectId _itemStoreObjectId;

    private readonly ITransactionSigner _signer = new TransactionSigner();
    private readonly ITransactionBuilderApi _builderApi;
    private readonly IQuorumApi _quorumApi;
    
    public ItemStoreCommandClient(IJsonRpcClient jsonRpcClient, Ed25519KeyPair keyPair, ObjectId packageId,
        ObjectId itemStoreObjectId, SuiAddress signerAddress)
    {
        _builderApi = new TransactionBuilderApi(jsonRpcClient);
        _quorumApi = new QuorumApi(jsonRpcClient);

        _keyPair = keyPair;
        _packageId = packageId;
        _itemStoreObjectId = itemStoreObjectId;
        _signerAddress = signerAddress;
    }
    
    public async Task BuyAndTake(string name, ObjectId[] coinIds)
    {
        var builder = await _builderApi.MoveCall(
            _signerAddress,
            _packageId,
            ModuleName,
            "buy_and_take",
            new[] { new SuiObjectType("0x2::sui::SUI") },
            new object[]{ _itemStoreObjectId, name, coinIds  },
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