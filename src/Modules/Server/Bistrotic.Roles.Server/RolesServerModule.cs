namespace Bistrotic.Roles
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.Roles.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public sealed class RolesServerModule : ServerModule
    {
        private RolesSettings? _settings;

        public RolesServerModule(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment)
        {
        }

        public RolesSettings Settings => _settings ??= Configuration.GetSettings<RolesSettings>();

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetRoleDetails).Assembly);
        }
    }
}