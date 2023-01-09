using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy;

public interface ICapyQueries
{
    public Task<Capy> GetCapy(ObjectId id);
    public Task<CapyItem[]> GetCapyItems(ObjectId capyObjectId);
    public Task<Capy[]> GetCapies(SuiAddress owner);
}