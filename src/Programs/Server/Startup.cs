namespace Bistrotic.Server
{
    using Bistrotic.Infrastructure.WebServer;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class Startup : ServerStartup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration) : base(environment, configuration)
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
    }
}