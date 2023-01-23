using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy.Capy;

public interface ICapyCommands
{
    public Task AddItem(ObjectId capyId, ObjectId item);
    public Task RemoveItem(ObjectId capyId, ObjectId item);
    public Task Breed(ObjectId capyOne, ObjectId capyTwo);
}