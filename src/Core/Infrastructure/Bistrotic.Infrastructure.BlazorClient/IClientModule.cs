using Bistrotic.Infrastructure.Modules;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Bistrotic.Infrastructure.BlazorClient
{
    public interface IClientModule : IModule
    {
        void ConfigureServices(IServiceCollection services);
    }
}