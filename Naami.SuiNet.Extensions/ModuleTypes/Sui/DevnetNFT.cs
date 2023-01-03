using Naami.SuiNet.Types;

namespace Naami.SuiNet.Extensions.ModuleTypes.Sui;

public record DevnetNFT(Uid Id, string Name, string Description, SuiObjectField<Url> Url);