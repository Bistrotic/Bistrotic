namespace Bistrotic.Infrastructure.WebServer.Modules
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

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

        Task StartAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken);

        Task StopAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken);
    }
}