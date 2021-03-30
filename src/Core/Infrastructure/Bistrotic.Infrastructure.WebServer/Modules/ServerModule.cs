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
        private IConfiguration? _configuration;

        private IWebHostEnvironment? _environment;

        protected ServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(ModuleType.Server)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration
        {
            get => _configuration ?? throw new ModuleNotInitializedException(nameof(_configuration));
            internal set => _configuration = value;
        }

        public IWebHostEnvironment Environment
        {
            get => _environment ?? throw new ModuleNotInitializedException(nameof(_environment));
            internal set => _environment = value;
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }

        public virtual void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
        }

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