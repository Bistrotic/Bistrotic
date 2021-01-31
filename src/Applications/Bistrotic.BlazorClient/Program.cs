namespace Bistrotic.Client
{
    using System.Threading.Tasks;

    public class Program : ClientProgram<App>
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }
    }
}