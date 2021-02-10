namespace Bistrotic.Infrastructure.WebServer.Modules
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure.Modules;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.Modules.Exceptions;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class ReflectionServerModuleActivator : IModuleActivator
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public ReflectionServerModuleActivator(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _environment = environment;
        }

        public Task<IModule?> FindModule(ModuleDefinition definition)
        {
            Type? moduleType = Type.GetType(definition.TypeName, false, false);
            if (moduleType == null)
            {
                return Task.FromResult<IModule?>(null);
            }
            return Task.FromResult((IModule?)(Activator.CreateInstance(moduleType, definition, _configuration, _environment) as IServerModule));
        }

        public Task<IModule> GetRequiredModule(ModuleDefinition definition)
        {
            Type? moduleType = Type.GetType(definition.TypeName, false, false);
            if (moduleType == null)
            {
                throw new ModuleNotFoundException(definition, $"Type {definition.TypeName} not found.");
            }
            return Task.FromResult((IModule?)(
                Activator.CreateInstance(moduleType, definition, _configuration) as IServerModule)
                    ?? throw new Exception($"Error while creating instance of {moduleType.FullName}."));
        }
    }
}