using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy.CapyPost;

public interface ICapyPostCommands
{
    public Task BuyGift(byte type, ObjectId[] coinIds);
    public Task SendGift(ObjectId giftBox, SuiAddress receiver);
    public Task OpenBox(ObjectId giftBox);

    public Task BuyPremium(ObjectId premiumTicket, ObjectId[] coinIds);
    public Task OpenPremium(ObjectId premiumBox);
}