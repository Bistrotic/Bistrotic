namespace Fiveforty.Module.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using Fiveforty.Module.Definitions;

    public class InvalidModuleDefinitionTypeException : InvalidModuleDefinitionException
    {
        public InvalidModuleDefinitionTypeException(ModuleDefinition definition) : this(definition, string.Empty)
        {
        }

        public InvalidModuleDefinitionTypeException(ModuleDefinition definition, string? message) : this(definition, message, null)
        {
        }

        public InvalidModuleDefinitionTypeException(ModuleDefinition definition, string? message, Exception? innerException) : base(definition, $"{nameof(ModuleDefinition.TypeName)} is mandatory. {message}\n", innerException)
        {
        }

        protected InvalidModuleDefinitionTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}