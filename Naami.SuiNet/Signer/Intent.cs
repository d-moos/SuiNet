namespace Naami.SuiNet.Signer;

public enum Scope : byte
{
    TransactionData = 0,
    TransactionEffects = 1,
    AuthorityBatch = 2,
    CheckpointSummary = 3,
    PersonalMessage = 4,
}

public enum AppId : byte
{
    Sui = 0,
}

public enum IntentVersion : byte
{
    V0 = 0,
}

public record Intent(
    Scope Scope,
    IntentVersion Version = IntentVersion.V0,
    AppId AppId = AppId.Sui
)
{
    public static implicit operator byte[](Intent intent) => new[]
    {
        (byte)intent.Scope,
        (byte)intent.Version,
        (byte)intent.AppId
    };
}