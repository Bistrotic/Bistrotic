namespace Bistrotic.Infrastructure.WebServer
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public static class ServerProgram
    {
        public static IWebHost CreateHost<TStartup>(string[] args)
            where TStartup : class
        {
            return CreateHostBuilder<TStartup>(args).Build();
        }

        public static IWebHostBuilder CreateHostBuilder<TStartup>(string[] args)
                    where TStartup : class
            => WebHost
               .CreateDefaultBuilder(args)
               .UseStartup<TStartup>()
               .CaptureStartupErrors(true);
    }
}