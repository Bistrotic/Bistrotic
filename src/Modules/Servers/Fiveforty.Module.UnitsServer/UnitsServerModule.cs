namespace Fiveforty.Module.UnitsServer
{
    using Fiveforty.Module.Abstractions;
    using Fiveforty.Module.Definitions;

    using Microsoft.Extensions.Configuration;

    public class UnitsServerModule : ServerModule
    {
        public UnitsServerModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(moduleDefinition, configuration)
        {
        }
    }
}