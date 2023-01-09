namespace Naami.SuiNet.Examples.Capy;

public interface ICapyAdminCommands
{
    public Task AddGene(string name, byte[][] definitions);
}