namespace Bistrotic.Application.WebServer
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public class ServerProgram<TStartup> where TStartup : class
    {
        public static IWebHost CreateHostBuilder(string[] args) =>
              WebHost
                .CreateDefaultBuilder<TStartup>(args)
                .CaptureStartupErrors(true)
                .Build();
    }
}