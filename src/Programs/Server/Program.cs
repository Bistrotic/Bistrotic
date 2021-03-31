namespace Bistrotic.Server
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public static class Program
    {
        // EF Core uses this method at design time to access the DbContext
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.ConfigureAppConfiguration(config => config.AddUserSecrets(typeof(Program).Assembly));
                    builder.ConfigureLogging(l => l.AddAzureWebAppDiagnostics());
                    builder.CaptureStartupErrors(true);
                    builder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                    builder.UseStartup<Startup>();
                });

        public static void Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .Run();
    }
}