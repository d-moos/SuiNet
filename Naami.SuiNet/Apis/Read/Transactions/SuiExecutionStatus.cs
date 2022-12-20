namespace Naami.SuiNet.Apis.Read.Transactions;

// TODO: test this weirdo
public record SuiExecutionStatus(ExecutionStatus ExecutionStatus)
{
    public string? Error { get; set; }
}