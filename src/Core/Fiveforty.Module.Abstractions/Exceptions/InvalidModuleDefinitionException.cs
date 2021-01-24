namespace Fiveforty.Module.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Text.Json;

    using Fiveforty.Module.Definitions;

    public class InvalidModuleDefinitionException : Exception
    {
        public InvalidModuleDefinitionException()
        {
        }

        public InvalidModuleDefinitionException(ModuleDefinition definition) : this(definition, string.Empty)
        {
        }

        public InvalidModuleDefinitionException(ModuleDefinition definition, string? message) : this(definition, message, null)
        {
        }

        public InvalidModuleDefinitionException(ModuleDefinition definition, string? message, Exception? innerException)
            : base($"Invalid module definition : {message}\nDefinition : {JsonSerializer.Serialize(definition)}", innerException)
        {
        }

        protected InvalidModuleDefinitionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}