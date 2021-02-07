namespace Bistrotic.Server
{
    using Bistrotic.Infrastructure.WebServer;
    using Bistrotic.Server.Data;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class Startup : ServerStartup<ApplicationDbContext>
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration) : base(env, configuration)
        {
        }
    }
}