namespace Fiveforty.Module.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Text.Json;

    using Fiveforty.Module.Definitions;

    public class ModuleNotFoundException : Exception
    {
        public ModuleNotFoundException()
        {
        }

        public ModuleNotFoundException(ModuleDefinition definition) : this(definition, string.Empty)
        {
        }

        public ModuleNotFoundException(ModuleDefinition definition, string? message) : this(definition, message, null)
        {
        }

        public ModuleNotFoundException(ModuleDefinition definition, string? message, Exception? innerException)
            : base($"Module with normalized name {definition.NormalizedName}, was not found. {message}\nDefinition : {JsonSerializer.Serialize(definition)}", innerException)
        {
        }

        protected ModuleNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}