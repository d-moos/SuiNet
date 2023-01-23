using Naami.SuiNet.Extensions.ModuleTypes.Sui;

namespace Naami.SuiNet.Examples.Capy.CapyPost.Types;

public record GiftBox(Uid Id, byte Type, Url Url, Url Link);