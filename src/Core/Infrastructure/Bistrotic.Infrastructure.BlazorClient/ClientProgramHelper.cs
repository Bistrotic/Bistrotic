namespace Bistrotic.BlazorClient
{
    using System;
    using System.Net.Http;

    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Configuration;

    public static class ClientProgramHelper
    {
        public static IServiceCollection AddBistroticClient(this IServiceCollection services, IWebAssemblyHostEnvironment hostEnvironment, string clientName, string serverApiName)
        {
            services.AddHttpClient(serverApiName, client => client.BaseAddress = new
                Uri(hostEnvironment.BaseAddress)).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the
            // server project
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(serverApiName));

            services.AddApiAuthorization(options =>
            {
                options.ProviderOptions.ConfigurationEndpoint = "_configuration/" + clientName;
            });
            services.AddOptions();
            return services;
        }

        public static ILoggingBuilder AddBistroticClient(this ILoggingBuilder logging)
        {
            logging.AddConfiguration();
            return logging;
        }
    }
}