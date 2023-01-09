using Naami.SuiNet.Extensions.ModuleTypes.Sui;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Examples.Capy;

public record ListedItem(Uid Id, Url Url, string Name, string Type, U64 Price)
{
    public U64? Quantity { get; set; }
}