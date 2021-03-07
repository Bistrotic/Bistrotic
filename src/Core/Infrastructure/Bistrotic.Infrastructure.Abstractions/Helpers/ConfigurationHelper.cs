using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bistrotic.Infrastructure.Helpers
{
    public static class ConfigurationHelper
    {
        public static TSettings GetSettings<TSettings>(this IConfiguration configuration) 
            => configuration
                .GetSection(typeof(TSettings).Name)
                .Get<TSettings>();
        public static IServiceCollection ConfigureSettings<TSettings>(this IServiceCollection services, IConfiguration configuration)
            where TSettings:class
            => services
                .Configure<TSettings>(configuration.GetSection(typeof(TSettings).Name));
    }
}
