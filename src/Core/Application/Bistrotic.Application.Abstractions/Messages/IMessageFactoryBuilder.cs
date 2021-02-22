using System;
using System.Reflection;

using Bistrotic.Domain.Messages;

namespace Bistrotic.Application.Messages
{
    public interface IMessageFactoryBuilder
    {
        IMessageFactoryBuilder AddAssemblyMessages(Assembly assembly);

        IMessageFactoryBuilder AddMessage<T>() where T : class, IMessage, new();

        IMessageFactory Build();
    }
}