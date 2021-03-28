namespace Bistrotic.Units
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.Units.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class UnitsServerModule : ServerModule
    {
        public UnitsServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetAllUnitIds).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
        }
    }
}