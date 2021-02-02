namespace Bistrotic.Application.Server
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class ServerProgram<TStartup> where TStartup : class
    {
        public static IWebHost CreateHostBuilder(string[] args) =>
              WebHost
                .CreateDefaultBuilder<TStartup>(args)
                .UseEnvironment("Development")
                .CaptureStartupErrors(true)
                .ConfigureAppConfiguration((hoistingContext, config) =>
                {
                    config
                    .AddEnvironmentVariables()
                    .AddCommandLine(args)
                    .Build();
                })
                .Build();
    }
}