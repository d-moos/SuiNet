namespace Naami.SuiSdk.Types;

public enum ExecuteTransactionRequestType
{
    ImmediateReturn,
    WaitForTxCert,
    WaitForEffectsCert,
    WaitForLocalExecution,
}