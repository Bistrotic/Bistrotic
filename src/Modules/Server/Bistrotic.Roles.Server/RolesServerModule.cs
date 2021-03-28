namespace Bistrotic.Roles
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.Roles.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class RolesServerModule : ServerModule
    {
        private readonly RolesSettings _settings;

        public RolesServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
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