namespace Bistrotic.BlazorClient
{
    using System.Threading.Tasks;

    using Bistrotic.Client;

    public class Program : ClientProgram<App>
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }
    }
}