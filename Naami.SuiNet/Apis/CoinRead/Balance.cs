using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.CoinRead;

public record Balance(SuiObjectType CoinType, uint CoinObjectCount, U128 TotalBalance);
