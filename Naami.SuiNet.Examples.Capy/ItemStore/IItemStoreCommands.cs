using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy.ItemStore;

public interface IItemStoreCommands
{
    public Task BuyAndTake(string name, ObjectId[] coinIds);
}