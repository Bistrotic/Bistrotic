using Bistrotic.Application.WebServer;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Bistrotic.WebServer
{
    public class Startup : ServerStartup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration) : base(env, configuration)
        {
        }
    }
}