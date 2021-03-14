﻿namespace Bistrotic.Infrastructure.CodeGeneration.Messages
{
    using System.Collections.Generic;
    internal sealed class CommandDefinition : MessageDefinition
    {
        public CommandDefinition(
            string name,
            string namespaceName,
            IEnumerable<PropertyDefinition> properties)
            : base(name, namespaceName, properties)
        {
        }
    }
}