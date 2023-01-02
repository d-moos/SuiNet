using Naami.SuiNet.Apis.Read;

namespace Naami.SuiNet.Extensions.TypeExtensions.Sui;

public record DevnetNFT(Uid Id, string Name, string Description, SuiObjectField<Url> Url);