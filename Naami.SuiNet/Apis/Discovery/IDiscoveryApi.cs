namespace Naami.SuiNet.Apis.Discovery;

public interface IDiscoveryApi
{
    Task<string> GetVersion();
}