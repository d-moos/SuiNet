using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Types;

public record Balance(SuiObjectType CoinType, uint CoinObjectCount, U128 TotalBalance);
