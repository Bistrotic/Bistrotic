namespace Bistrotic.Infrastructure.WebServer
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public abstract class ServerProgram<TStartup> where TStartup : class
    {
        private readonly string[] _args;

        private IHost? _host;
        private IHostBuilder? _hostBuilder;

        protected ServerProgram(string[] args)
        {
            _args = args;
        }

        public IHost Host => _host ??= CreateHost();
        public IHostBuilder HostBuilder => _hostBuilder ??= CreateHostBuilder();

        public void AddModule<TModule>(IServiceCollection services)
            where TModule : class, IServerModule
        {
            services.AddSingleton<IServerModule, TModule>();
            services.AddMvc().AddApplicationPart(typeof(TModule).Assembly);
        }

        public abstract void AddModules(IServiceCollection services);

        public IHost CreateHost()
            => HostBuilder.Build();

        public IHostBuilder CreateHostBuilder()
            => Microsoft.Extensions.Hosting.Host
                .CreateDefaultBuilder(_args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        AddModules(services);
                    });
                    builder.UseStartup<TStartup>();
                    builder.CaptureStartupErrors(true);
                });

        public Task StartAsync()
        {
            if (_host == null)
            {
                return Task.CompletedTask;
            }
            return _host.StartAsync();
        }

        public async Task StopAsync()
        {
            if (_host != null)
            {
                using (_host)
                {
                    await _host
                        .StopAsync(TimeSpan.FromSeconds(5))
                        .ConfigureAwait(false);
                }
                _host = null;
            }
        }
    }
}