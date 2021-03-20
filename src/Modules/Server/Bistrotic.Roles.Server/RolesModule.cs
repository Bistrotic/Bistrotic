namespace Bistrotic.Roles
{

    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.Roles.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;


    public sealed class RolesModule : ServerModule
    {
        private readonly RolesSettings _settings;

        public RolesModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(moduleDefinition, configuration, environment, clientMode)
        {
            _settings = configuration.GetSettings<RolesSettings>();
        }



        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetRoleDetails).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
        }
    }
}