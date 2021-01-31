using Bistrotic.Application.Server;

using Microsoft.AspNetCore.Hosting;

namespace Bistrotic.Server
{
    public class Startup : ServerStartup
    {
        public Startup(IWebHostEnvironment env) : base(env)
        {
        }
    }
}