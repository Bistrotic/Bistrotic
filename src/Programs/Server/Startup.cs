namespace Bistrotic.Server
{
    using System.Collections.Generic;

    using Bistrotic.Infrastructure.WebServer;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class Startup : ServerStartup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
            : base(environment, configuration)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, IEnumerable<IServerModule> modules)
        {
            base.Configure(app, env, modules);

            app.UseEndpoints(endpoints =>
                {
                    endpoints.Map("api/{**slug}", HandleApiFallback);
                    endpoints.MapRazorPages();
                    endpoints.MapControllers();
                    endpoints.MapFallbackToFile("index.html");
                });
        }
    }
}