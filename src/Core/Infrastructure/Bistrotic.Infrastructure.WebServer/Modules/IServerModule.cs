namespace Bistrotic.Infrastructure.WebServer.Modules
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure.Modules;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public interface IServerModule : IModule
    {
        void Configure(IApplicationBuilder app, IWebHostEnvironment env);

        void ConfigureMessages(IMessageFactoryBuilder messageBuilder);

        void ConfigureServices(IServiceCollection services);

        void OnStarted();

        void OnStopped();

        void OnStopping();
    }
}