using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy;

public interface ICapyPostQueries
{
    public Task<CapyPost> GetPost();
    public Task<GiftBox[]> GetGiftBoxes(SuiAddress owner);
    public Task<PremiumBox[]> GetPremiumBoxes(SuiAddress owner);
    public Task<PremiumTicket[]> GetPremiumTickets(SuiAddress owner);
    public byte[] AvailableGiftTypes();
}