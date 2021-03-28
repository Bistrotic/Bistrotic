namespace Bistrotic.Infrastructure.WebServer.Modules
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure.Modules;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class ServerModule : ModuleBase, IServerModule
    {
        protected ServerModule(IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(ModuleType.Server)
        {
            Configuration = configuration;
            Environment = environment;
            ClientMode = clientMode;
        }

        public ClientMode ClientMode { get; }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }

        public abstract void ConfigureMessages(IMessageFactoryBuilder messageBuilder);

        public abstract void ConfigureServices(IServiceCollection services);

        public virtual void OnStarted()
        {
        }

        public virtual void OnStopped()
        {
        }

        public virtual void OnStopping()
        {
        }
    }
}