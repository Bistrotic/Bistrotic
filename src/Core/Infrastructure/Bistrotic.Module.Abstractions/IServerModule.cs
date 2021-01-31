namespace Fiveforty.Module.Abstractions
{
    public interface IServerModule : IModule
    {
        string ServiceName { get; set; }
    }
}