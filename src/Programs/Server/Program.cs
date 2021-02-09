namespace Bistrotic.Server
{
    using Bistrotic.Infrastructure.WebServer;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public static class Program
    {
        public static void Main(string[] args)
        {
            ServerProgram.CreateHostBuilder<Startup>(args).Run();
        }
    }
}