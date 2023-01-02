using Naami.SuiNet.Types;

namespace Naami.SuiNet.Extensions.TypeExtensions.Sui;

public class Uid
{
    public Uid(ObjectId id)
    {
        Id = id;
    }

    public ObjectId Id { get; set; }
}