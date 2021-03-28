namespace Bistrotic.WorkItems.Presentation
{
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class WorkItemClientModule : ClientModule
    {
        public WorkItemClientModule(
            IWebAssemblyHostEnvironment hostEnvironment,
            string clientName,
            string serverApiName,
            ClientMode clientMode)
            : base(hostEnvironment, clientName, serverApiName, clientMode)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
        }
    }
}