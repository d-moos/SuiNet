using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy;

public class CapyPostQueryClient : ICapyPostQueries
{
    private const string ModuleName = "capy_winter";
    private const byte GIFTTYPES = 8;

    private readonly ObjectId _packageId;
    private readonly ObjectId _capyPostId;
    
    private readonly IReadApi _readApi;

    public CapyPostQueryClient(IJsonRpcClient jsonRpcClient, ObjectId packageId, ObjectId capyPostId)
    {
        _packageId = packageId;
        _capyPostId = capyPostId;
        
        _readApi = new ReadApi(jsonRpcClient);
    }
    
    public async Task<CapyPost> GetPost()
    {
        var response = await _readApi.GetObject<CapyPost>(_capyPostId);
        return response.ExistsResult!.Data.Fields!;
    }

    public Task<GiftBox[]> GetGiftBoxes(SuiAddress owner)
        => GetObjects<GiftBox>(owner, "GiftBox");

    public Task<PremiumBox[]> GetPremiumBoxes(SuiAddress owner)
        => GetObjects<PremiumBox>(owner, "PremiumBox");

    public Task<PremiumTicket[]> GetPremiumTickets(SuiAddress owner)
        => GetObjects<PremiumTicket>(owner, "PremiumTicket");

    private async Task<T[]> GetObjects<T>(SuiAddress owner, string structName)
    {
        var giftBoxIds = (await _readApi.GetObjectsOwnedByAddress(owner))
            .Where(x => x.Type.Package == _packageId)
            .Where(x => x.Type.Module == ModuleName)
            .Where(x => x.Type.Struct.Name == structName)
            .Select(x => x.ObjectId);

        var tasks = giftBoxIds.Select(_readApi.GetObject<T>);

        await Task.WhenAll(tasks);

        return tasks.Select(x => x.Result.ExistsResult!.Data.Fields!).ToArray();
    }

    public byte[] AvailableGiftTypes() => Enumerable.Range(0, GIFTTYPES)
        .Select(x => (byte)x)
        .ToArray();
}