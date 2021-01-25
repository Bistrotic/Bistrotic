namespace Fiveforty.Module
{
    using System;
    using System.Threading.Tasks;

    using Fiveforty.Module.Definitions;
    using Fiveforty.Module.Exceptions;

    public class ReflectionModuleActivator : IModuleActivator
    {
        public Task<IModule?> FindModule(ModuleDefinition definition)
        {
            Type? moduleType = Type.GetType(definition.TypeName, false, false);
            if (moduleType == null)
            {
                return Task.FromResult<IModule?>(null);
            }
            return Task.FromResult(Activator.CreateInstance(moduleType) as IModule);
        }

        public Task<IModule> GetRequiredModule(ModuleDefinition definition)
        {
            Type? moduleType = Type.GetType(definition.TypeName, false, false);
            if (moduleType == null)
            {
                throw new ModuleNotFoundException(definition, $"Type {definition.TypeName} not found.");
            }
            return Task.FromResult(
                Activator.CreateInstance(moduleType, definition) as IModule
                    ?? throw new Exception($"Error while creating instance of {moduleType.FullName}."));
        }
    }
}