namespace Bistrotic.Users
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.Users.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class UsersServerModule : ServerModule
    {
        public UsersServerModule(IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(configuration, environment, clientMode)
        {
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetAllUserIds).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
        }
    }
}