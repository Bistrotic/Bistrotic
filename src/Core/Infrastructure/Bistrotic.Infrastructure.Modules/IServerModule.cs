namespace Bistrotic.Infrastructure.Modules.Abstractions
{
    public interface IServerModule : IModule
    {
        string ServiceName { get; set; }
    }
}