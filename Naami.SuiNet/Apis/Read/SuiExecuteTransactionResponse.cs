namespace Naami.SuiNet.Apis.Read;

public record SuiExecuteTransactionResponse
{
    public ImmediateReturn? ImmediateReturn { get; set; }
    public TxCert? TxCert { get; set; }
    public EffectsCert? EffectsCert { get; set; }
};