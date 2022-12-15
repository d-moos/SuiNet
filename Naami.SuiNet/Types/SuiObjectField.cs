using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types;

public record SuiObjectField<T>(SuiObjectType Type, T Fields);