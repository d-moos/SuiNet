using Naami.SuiNet.Types;

namespace Naami.SuiNet.Extensions.TypeExtensions.Sui;

public record MintNFTEvent(ObjectId ObjectId, SuiAddress Creator, string Name);