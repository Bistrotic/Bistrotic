namespace Bistrotic.Infrastructure.WebServer
{
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public abstract class ServerProgram<TStartup> where TStartup : class
    {
        private readonly string[] _args;

        private IHostBuilder? _hostBuilder;

        protected ServerProgram(string[] args)
        {
            _args = args;
        }

        public IHostBuilder HostBuilder => _hostBuilder ??= CreateHostBuilder();

        public void AddModule<TModule>(IServiceCollection services)
            where TModule : class, IServerModule
        {
            services.AddSingleton<IServerModule, TModule>();
            services.AddMvc()
                .AddApplicationPart(typeof(TModule).Assembly);
        }

        public abstract void AddModules(IServiceCollection services);

        public IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder(_args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        AddModules(services);
                    });
                    builder.ConfigureLogging(l =>
                    {
                        l.AddAzureWebAppDiagnostics();
                    });
                    builder.UseStartup<TStartup>();
                    builder.CaptureStartupErrors(true);
                    builder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                });
    }
}