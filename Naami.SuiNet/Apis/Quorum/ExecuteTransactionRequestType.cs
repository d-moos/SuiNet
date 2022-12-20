namespace Naami.SuiNet.Apis.Quorum;

public enum ExecuteTransactionRequestType
{
    ImmediateReturn,
    WaitForTxCert,
    WaitForEffectsCert,
    WaitForLocalExecution,
}