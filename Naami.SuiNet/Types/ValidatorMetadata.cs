using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Types;

public record ValidatorMetadata(
    SuiAddress SuiAddress,
    byte[] PubkeyBytes,
    byte[] NetworkPubkeyBytes,
    byte[] WorkerPubkeyBytes,
    byte[] ProofOfPossessionBytes,
    byte[] Name,
    byte[] Description,
    byte[] ImageUrl,
    byte[] ProjectUrl,
    byte[] NetAddress,
    U64 NextEpochStake,
    U64 NextEpochDelegation,
    U64 NextEpochGasPrice,
    U64 NextEpochCommissionRate
);