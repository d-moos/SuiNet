namespace Naami.SuiNet.Types;

public record SuiExecuteTransactionResponse
{
    public ImmediateReturn? ImmediateReturn { get; set; }
    public TxCert? TxCert { get; set; }
    public EffectsCert? EffectsCert { get; set; }
};