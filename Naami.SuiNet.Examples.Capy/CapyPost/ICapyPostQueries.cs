using Naami.SuiNet.Examples.Capy.CapyPost.Types;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy.CapyPost;

public interface ICapyPostQueries
{
    public Task<Types.CapyPost> GetPost();
    public Task<GiftBox[]> GetGiftBoxes(SuiAddress owner);
    public Task<PremiumBox[]> GetPremiumBoxes(SuiAddress owner);
    public Task<PremiumTicket[]> GetPremiumTickets(SuiAddress owner);
    public byte[] AvailableGiftTypes();
}