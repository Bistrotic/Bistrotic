﻿namespace Bistrotic.Infrastructure.WebServer.Modules
{
    using Bistrotic.Infrastructure.Modules;
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class ServerModule : Module, IServerModule
    {
        protected ServerModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode) : base(ModuleType.Server, moduleDefinition)
        {
            Configuration = configuration;
            Environment = environment;
            ClientMode = clientMode;
        }

        public ClientMode ClientMode { get; }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public abstract void ConfigureServices(IServiceCollection services);
    }
}