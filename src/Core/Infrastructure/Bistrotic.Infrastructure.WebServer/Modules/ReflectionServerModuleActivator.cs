﻿namespace Bistrotic.Infrastructure.WebServer.Modules
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
        private readonly ClientMode _clientMode;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public ReflectionServerModuleActivator(IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _environment = environment;
            _clientMode = clientMode;
        }

        public Task<IModule?> FindModule(ModuleDefinition definition)
        {
            Type? moduleType = Type.GetType(definition.TypeName, false, false);
            if (moduleType == null)
            {
                return Task.FromResult<IModule?>(null);
            }
            var module = Activator.CreateInstance(moduleType, definition, _configuration, _environment, _clientMode) as IServerModule;
            if (module != null)
            {
                Console.WriteLine("Module activated : " + moduleType.Name);
            }
            return Task.FromResult((IModule?)module);
        }

        public Task<IModule> GetRequiredModule(ModuleDefinition definition)
        {
            Type? moduleType = Type.GetType(definition.TypeName, false, false);
            if (moduleType == null)
            {
                return Task.FromException<IModule>(new ModuleNotFoundException(definition, $"Type {definition.TypeName} not found."));
            }
            IModule? module = Activator.CreateInstance(moduleType, definition, _configuration, _environment, _clientMode) as IServerModule;
            if (module == null)
            {
                return Task.FromException<IModule>(new ModuleInstanceNotCreatedException($"Error while creating instance of {moduleType.FullName}."));
            }
            Console.WriteLine("Module activated : " + moduleType.Name);

            return Task.FromResult(module);
        }
    }
}