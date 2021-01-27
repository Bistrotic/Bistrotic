namespace Fiveforty.Module.UnitsClient
{
    using Fiveforty.Module.Definitions;

    using Microsoft.Extensions.Configuration;

    public class UnitClientModule : ClientModule
    {
        public UnitClientModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(moduleDefinition, configuration)
        {
        }
    }
}