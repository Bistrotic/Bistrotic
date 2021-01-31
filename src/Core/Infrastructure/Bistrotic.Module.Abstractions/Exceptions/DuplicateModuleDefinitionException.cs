namespace Fiveforty.Module.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DuplicateModuleDefinitionException : Exception
    {
        public DuplicateModuleDefinitionException() : this(new string[] { string.Empty }, string.Empty, null)
        {
        }

        public DuplicateModuleDefinitionException(string[] duplicates) : this(duplicates, string.Empty, null)
        {
        }

        public DuplicateModuleDefinitionException(string[] duplicateNames, string? message, Exception? innerException)
            : base($"Duplicate module definition(s) : {string.Join(',', duplicateNames)}.\n{message}", innerException)
        {
        }

        protected DuplicateModuleDefinitionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}