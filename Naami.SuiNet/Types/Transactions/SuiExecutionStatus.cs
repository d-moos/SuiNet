namespace Naami.SuiNet.Types.Transactions;

// TODO: test this weirdo
public record SuiExecutionStatus(ExecutionStatus ExecutionStatus)
{
    public string? Error { get; set; }
}