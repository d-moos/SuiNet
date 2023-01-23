using Naami.SuiNet.Examples.Capy.Capy.Types;

namespace Naami.SuiNet.Examples.Capy.ItemStore;

public interface IItemStoreQueries
{
    public Task<Capy.Types.ItemStore> GetStore();
    public Task<ListedItem[]> GetAvailableItems();
}