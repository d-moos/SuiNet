using Naami.SuiNet.Types;

namespace Naami.SuiNet.Extensions.ModuleTypes.Sui;

public record MintNFTEvent(ObjectId ObjectId, SuiAddress Creator, string Name);