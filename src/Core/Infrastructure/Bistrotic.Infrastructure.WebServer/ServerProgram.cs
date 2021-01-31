namespace Bistrotic.Application.Server
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class ServerProgram<TStartup> where TStartup : class
    {
        public static IWebHost CreateHostBuilder(string[] args) =>
              WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<TStartup>()
                .Build();
    }
}