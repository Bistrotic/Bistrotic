using Microsoft.Extensions.DependencyInjection;

namespace Bistrotic.Infrastructure.Modules
{
    public interface IServerModule : IModule
    {
        void ConfigureServices(IServiceCollection services);
    }
}