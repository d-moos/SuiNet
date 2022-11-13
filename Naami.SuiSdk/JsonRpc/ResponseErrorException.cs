namespace Naami.SuiSdk.JsonRpc;

public class ResponseErrorException : Exception
{
    public ResponseErrorException(string message) : base(message)
    {
    }
}