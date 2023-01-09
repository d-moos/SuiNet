using Naami.SuiNet.Examples.Capy.Capy.Types;

namespace Naami.SuiNet.Examples.Capy;

public interface IItemStoreQueries
{
    public Task<ItemStore> GetStore();
    public Task<ListedItem[]> GetAvailableItems();
}