using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Governance;

public record LinkedTable<T>(ObjectId Id, U64 Size)
{
    public T[]? Head { get; init; }
    public T[]? Tail { get; init; }
}