using Naami.SuiNet.Apis.Quorum;
using Naami.SuiNet.Apis.TransactionBuilder;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Signer;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy.CapyPost;

public class CapyPostCommandClient : ICapyPostCommands
{
    private const string ModuleName = "capy_winter";

    private readonly Ed25519KeyPair _keyPair;
    private readonly SuiAddress _signerAddress;

    private readonly ObjectId _packageId;
    private readonly ObjectId _capyPostObjectId;
    private readonly ObjectId _capyRegistryObjectId;

    private readonly ITransactionSigner _signer = new TransactionSigner();
    private readonly ITransactionBuilderApi _builderApi;
    private readonly IQuorumApi _quorumApi;

    public CapyPostCommandClient(IJsonRpcClient jsonRpcClient, Ed25519KeyPair keyPair, ObjectId packageId,
        ObjectId capyPostObjectId, ObjectId capyRegistryObjectId, SuiAddress signerAddress)
    {
        _builderApi = new TransactionBuilderApi(jsonRpcClient);
        _quorumApi = new QuorumApi(jsonRpcClient);

        _keyPair = keyPair;
        _packageId = packageId;
        _capyPostObjectId = capyPostObjectId;
        _capyRegistryObjectId = capyRegistryObjectId;
        _signerAddress = signerAddress;
    }

    public Task BuyGift(byte type, ObjectId[] coinIds)
        => ExecuteTransaction("buy_gift", new[] { new SuiObjectType("0x2::sui::SUI") },
            new[] { _capyPostObjectId, (object)type, coinIds });

    public Task SendGift(ObjectId giftBox, SuiAddress receiver)
        => ExecuteTransaction("send_gift", Array.Empty<SuiObjectType>(),
            new[] { _capyPostObjectId, (object)giftBox, receiver });

    public Task OpenBox(ObjectId giftBox)
        => ExecuteTransaction("buy_premium", Array.Empty<SuiObjectType>(),
            new[] { _capyRegistryObjectId, (object)giftBox });
    
    public Task BuyPremium(ObjectId premiumTicket, ObjectId[] coinIds)
        => ExecuteTransaction("buy_premium", new[] { new SuiObjectType("0x2::sui::SUI") },
            new[] { _capyPostObjectId, (object)premiumTicket, coinIds });

    public Task OpenPremium(ObjectId premiumBox)
        => ExecuteTransaction("open_premium", Array.Empty<SuiObjectType>(),
            new[] { _capyRegistryObjectId, (object)premiumBox });


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
            Convert.ToBase64String(_keyPair.PublicKey),
            ExecuteTransactionRequestType.WaitForEffectsCert
        );
    }
}