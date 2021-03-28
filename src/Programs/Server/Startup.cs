namespace Bistrotic.Server
{
    using System.Collections.Generic;

    using Bistrotic.Infrastructure.WebServer;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup : ServerStartup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration, IEnumerable<IServerModule> modules)
            : base(environment, configuration, modules)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);

            app.UseEndpoints(endpoints =>
                {
                    endpoints.Map("api/{**slug}", HandleApiFallback);
                    endpoints.MapRazorPages();
                    endpoints.MapControllers();
                    endpoints.MapFallbackToFile("index.html");
                });
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
        }
    }
}