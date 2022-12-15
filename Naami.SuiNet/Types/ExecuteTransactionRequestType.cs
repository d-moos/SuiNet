namespace Naami.SuiNet.Types;

public enum ExecuteTransactionRequestType
{
    ImmediateReturn,
    WaitForTxCert,
    WaitForEffectsCert,
    WaitForLocalExecution,
}