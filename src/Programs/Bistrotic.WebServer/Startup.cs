using Bistrotic.Application.Server;

using Microsoft.AspNetCore.Hosting;

namespace Bistrotic.WebServer
{
    public class Startup : ServerStartup
    {
        public Startup(IWebHostEnvironment env) : base(env)
        {
        }
    }
}