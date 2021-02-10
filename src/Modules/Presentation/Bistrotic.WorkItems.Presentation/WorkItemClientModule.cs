using System;

using Bistrotic.Infrastructure.BlazorClient;
using Bistrotic.Infrastructure.Modules.Definitions;

using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Bistrotic.WorkItems.Presentation
{
    public class WorkItemClientModule : ClientModule
    {
        public WorkItemClientModule(ModuleDefinition moduleDefinition, IWebAssemblyHostEnvironment hostEnvironment, string clientName, string serverApiName)
            : base(moduleDefinition, hostEnvironment, clientName, serverApiName)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHttpClient<WorkItemHttpClient>(
                    _serverApiName,
                    client =>
                        client.BaseAddress = new Uri(Environment.BaseAddress))
                                                    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
        }
    }
}