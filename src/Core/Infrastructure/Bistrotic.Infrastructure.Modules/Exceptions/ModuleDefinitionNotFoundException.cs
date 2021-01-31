namespace Bistrotic.Infrastructure.Modules.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ModuleDefinitionNotFoundException : Exception
    {
        public ModuleDefinitionNotFoundException()
        {
        }

        public ModuleDefinitionNotFoundException(string name, string? message = null, Exception? innerException = null)
             : base($"Module definition with normalized name {name}, was not found. {message}", innerException)
        {
            NotFoundName = name;
        }

        protected ModuleDefinitionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string NotFoundName { get; } = string.Empty;
    }
}