namespace Bistrotic.Infrastructure.InMemory.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Bistrotic.Application.Messages;
    using Bistrotic.Domain.Messages;

    public class InMemoryMessageFactoryBuilder : IMessageFactoryBuilder
    {
        private readonly HashSet<Type> _messageTypes = new();

        public IMessageFactoryBuilder AddAssemblyMessages(Assembly assembly)
        {
            foreach (Type t in assembly
                .GetTypes()
                .Where(p => p.IsClass && !p.IsAbstract && typeof(IMessage).IsAssignableFrom(p)))
            {
                _messageTypes.Add(t);
                Console.WriteLine("Message added : " + t.Name);
            }
            return this;
        }

        public IMessageFactoryBuilder AddMessage<T>() where T : class, IMessage, new()
        {
            _messageTypes.Add(typeof(T));
            return this;
        }

        public IMessageFactory Build()
            => new InMemoryMessageFactory(_messageTypes);
    }
}