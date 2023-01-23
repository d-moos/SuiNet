using Naami.SuiNet.Examples.Capy.Capy.Events;
using Naami.SuiNet.Examples.Capy.Capy.Types;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy.Capy;

public interface ICapyQueries
{
    public Task<Capy.Types.Capy> GetCapy(ObjectId id);
    public Task<CapyItem[]> GetCapyItems(ObjectId capyObjectId);
    public Task<Capy.Types.Capy[]> GetCapies(SuiAddress owner);

    public IAsyncEnumerable<CapyBorn> StreamCapyBornEvents(EventId? cursor = null);
}