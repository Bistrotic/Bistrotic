using System;
using System.Runtime.Serialization;

using Fiveforty.Module.Definitions;

namespace Fiveforty.Module.Exceptions
{
    public class ModuleDefinitionDependencyNotFoundException : InvalidModuleDefinitionException
    {
        public ModuleDefinitionDependencyNotFoundException()
        {
        }

        public ModuleDefinitionDependencyNotFoundException(ModuleDefinition definition, string dependency, string? message = null, Exception? innerException = null) : base(definition, $"Module for dependency {dependency} not found. {message}\n", innerException)
        {
        }

        protected ModuleDefinitionDependencyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}