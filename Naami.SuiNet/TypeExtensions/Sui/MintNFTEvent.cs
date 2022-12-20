using Naami.SuiNet.Types;

namespace Naami.SuiNet.TypeExtensions.Sui;

public record MintNFTEvent(ObjectId ObjectId, SuiAddress Creator, string Name);