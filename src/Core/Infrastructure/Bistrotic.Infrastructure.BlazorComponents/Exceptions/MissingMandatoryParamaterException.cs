namespace Bistrotic.Infrastructure.BlazorComponents.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using Bistrotic.Infrastructure.BlazorComponents.Themes;

    using Microsoft.AspNetCore.Components;

    [Serializable]
    internal class MissingMandatoryParamaterException<TComponent> : Exception
        where TComponent : ComponentBase
    {
        public MissingMandatoryParamaterException() : this(null, null)
        {
        }

        public MissingMandatoryParamaterException(string parameterName) : this(parameterName, null, null)
        {
        }

        public MissingMandatoryParamaterException(string parameterName, string? message, Exception? innerException)
            : base($"The mandatory parameter '{parameterName}' is not defined in the '{typeof(Theme).Name}' component. {message}", innerException)
        {
        }

        public MissingMandatoryParamaterException(string? message, Exception? innerException)
            : base($"A mandatory parameter is not defined in the '{typeof(Theme).Name}' component. {message}", innerException)
        {
        }

        protected MissingMandatoryParamaterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}