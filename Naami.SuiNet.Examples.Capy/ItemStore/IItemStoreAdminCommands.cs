using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Examples.Capy.ItemStore;

public interface IItemStoreAdminCommands
{
    public Task SetQuantity(string name, U64 quantity);
    public Task CollectProfits();
    public Task Sell(string name, string type, U64 price);
}