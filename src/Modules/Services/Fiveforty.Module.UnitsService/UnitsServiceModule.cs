namespace Fiveforty.Module.UnitsService
{
    using Fiveforty.Module.Abstractions;
    using Fiveforty.Module.Definitions;

    using Microsoft.Extensions.Configuration;

    public class UnitsServiceModule : ServiceModule
    {
        public UnitsServiceModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(moduleDefinition, configuration)
        {
        }
    }
}