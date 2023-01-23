using Naami.SuiNet.Examples.Capy.ItemStore;
using Naami.SuiNet.JsonRpc;

namespace Naami.SuiNet.Examples.Capy.Test;

public class Tests
{
    private readonly ItemStoreQueryClient _itemStoreQueryClient = new(
        new JsonRpcClient("https://fullnode.devnet.sui.io"),
        "0x30136e80e16ac92ff33a0ac2d67c64dc129eb0bc",
        "0x3c4706fd9deec1674137d92c1a2296001489fa46"
    );

    [Test]
    public async Task ItemStore()
    {
        var store = await _itemStoreQueryClient.GetStore();
        Assert.That(!string.IsNullOrEmpty(store.Balance));
    }
    
    [Test]
    public async Task ItemStore_Items()
    {
        var store = await _itemStoreQueryClient.GetAvailableItems();
        Assert.That(store.Length > 0);
    }
}