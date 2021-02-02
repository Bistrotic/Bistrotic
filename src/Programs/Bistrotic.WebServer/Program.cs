namespace Bistrotic.WebServer
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Server;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class Program : ServerProgram<Startup>
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunAsync();
        }
    }
}