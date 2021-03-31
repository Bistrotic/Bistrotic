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
                 .AddHttpClient<BistroticHttpClient>(serverApiName, client =>
                            client.BaseAddress = new Uri(hostEnvironment.BaseAddress)
                         )
                         .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            // Supply HttpClient instances that include access tokens when making requests to the
            // server project
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(serverApiName));

            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.ClientId = serverApiName;
                options.ProviderOptions.Authority = hostEnvironment.BaseAddress;
                options.ProviderOptions.ResponseType = "code";

                // Note: response_mode=fragment is the best option for a SPA. Unfortunately, the
                // Blazor WASM authentication stack is impacted by a bug that prevents it from
                // correctly extracting authorization error responses (e.g error=access_denied
                // responses) from the URL fragment. For more information about this bug, visit https://github.com/dotnet/aspnetcore/issues/28344.
                options.ProviderOptions.ResponseMode = "query";
                options.AuthenticationPaths.RemoteRegisterPath = new Uri(new Uri(hostEnvironment.BaseAddress), "Identity/Account/Register").ToString();
            });
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
            foreach (IClientModule module in GetClientModules(hostEnvironment, clientName, serverApiName))
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
                .Where(p => IsClientModule(p.GetType()))
                .Cast<IClientModule>()
                .ToArray();
        }

        private static bool IsClientModule(Type p)
        {
            if (p.IsClass && !p.IsAbstract)
            {
                return typeof(IClientModule).IsAssignableFrom(p);
            }
            return false;
        }
    }
}