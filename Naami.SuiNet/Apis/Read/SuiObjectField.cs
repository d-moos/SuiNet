using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read;

public record SuiObjectField<T>(SuiObjectType Type, T Fields);