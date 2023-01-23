using Naami.SuiNet.Examples.Capy.CapyPost;
using Naami.SuiNet.JsonRpc;

namespace Naami.SuiNet.Examples.Capy.Test;

public class CapyPostQueryClientSpecifications
{
    private readonly CapyPostQueryClient _queryClient
        = new (
            new JsonRpcClient("https://fullnode.devnet.sui.io"),
            "0x30136e80e16ac92ff33a0ac2d67c64dc129eb0bc",
            "0xf13062d96a9a595bd186c9e33b053f75a21c9698"
        );

    [Test]
    public async Task GetCapyPost()
    {
        var response = await _queryClient.GetPost();
        Assert.That(!string.IsNullOrEmpty(response.Balance));
    }
    
    [Test]
    public async Task GetGiftBoxes()
    {
        var response = await _queryClient.GetGiftBoxes("0x72a234bbe890602bb4b1a4bcf4a80f61c7244f63");
        var i = 0;
    }
    
    [Test]
    public async Task GetPremiumBoxes()
    {
        var response = await _queryClient.GetPremiumBoxes("0x72a234bbe890602bb4b1a4bcf4a80f61c7244f63");
        var i = 0;
    }
    
    [Test]
    public async Task GetPremiumTickets()
    {
        var response = await _queryClient.GetPremiumTickets("0x72a234bbe890602bb4b1a4bcf4a80f61c7244f63");
        var i = 0;
    }
}