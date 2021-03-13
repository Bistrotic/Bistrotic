﻿namespace Bistrotic.Infrastructure.CodeGeneration.Messages
{
    public class MessageDefinition
    {
        public MessageDefinition(string name, string namespaceName)
        {
            this.Name = name;
            this.Namespace = namespaceName;
        }

        public string Name { get; }
        public string Namespace { get; set; }
    }
}