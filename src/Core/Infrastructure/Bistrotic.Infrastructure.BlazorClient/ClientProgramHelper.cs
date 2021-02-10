namespace Bistrotic.Infrastructure.BlazorClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    using Bistrotic.Infrastructure.Modules;
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Configuration;

    public static class ClientProgramHelper
    {
        public static IServiceCollection AddBistroticClient(this IServiceCollection services, IWebAssemblyHostEnvironment hostEnvironment, string clientName, string serverApiName)
        {
            services
                 .AddHttpClient<HttpClient>(
                     serverApiName,
                     client =>
                         client.BaseAddress = new Uri(hostEnvironment.BaseAddress))
                                                     .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            // Supply HttpClient instances that include access tokens when making requests to the
            // server project
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(serverApiName));

            services.AddApiAuthorization(options => options.ProviderOptions.ConfigurationEndpoint = "_configuration/" + clientName);
            services.AddOptions();
            services.AddBistroticClientModules(hostEnvironment, clientName, serverApiName);
            return services;
        }

        public static ILoggingBuilder AddBistroticClient(this ILoggingBuilder logging)
        {
            logging.AddConfiguration();
            return logging;
        }

        public static IServiceCollection AddBistroticClientModules(this IServiceCollection services, IWebAssemblyHostEnvironment hostEnvironment, string clientName, string serverApiName)
        {
            foreach (IClientModule module in ClientProgramHelper.GetClientModules(hostEnvironment, clientName, serverApiName))
            {
                module.ConfigureServices(services);
            }
            return services;
        }

        private static IEnumerable<IClientModule> GetClientModules(IWebAssemblyHostEnvironment hostEnvironment, string clientName, string serverApiName)
        {
            var modules = new ModuleFactory(
                new Func<IModuleDefinitionLoader>[] { () => new ReflectionClientModuleDefinitionLoader() },
                new Func<IModuleActivator>[] { () => new ReflectionClientModuleActivator(hostEnvironment, clientName, serverApiName) });
            return modules.GetModules()
                .GetAwaiter()
                .GetResult()
                .OfType<IClientModule>()
                .Select(p => p);
        }
    }
}