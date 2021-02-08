namespace Bistrotic.Client
{
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

    public static class Program
    {
        public static Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBistroticClient(builder.HostEnvironment, typeof(Program).Namespace ?? string.Empty, BistroticConstants.ServerApiName);

            builder.Logging.AddBistroticClient();
            return builder.Build().RunAsync();
        }
    }
}