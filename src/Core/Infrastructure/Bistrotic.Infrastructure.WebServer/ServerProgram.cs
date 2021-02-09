namespace Bistrotic.Infrastructure.WebServer
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public static class ServerProgram
    {
        public static IWebHost CreateHostBuilder<TStartup>(string[] args)
            where TStartup : class
            =>
             WebHost
               .CreateDefaultBuilder<TStartup>(args)
               .CaptureStartupErrors(true)
               .Build();
    }
}