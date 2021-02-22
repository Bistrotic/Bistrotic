using System;

using Bistrotic.Domain.Messages;

namespace Bistrotic.Application.Messages
{
    public interface IMessageFactory
    {
        IMessage GetMessage(string name, string jsonValue);

        Type GetMessageType(string name);
    }
}