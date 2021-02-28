using System;
using System.Collections.Generic;

using Bistrotic.Domain.Messages;

using Microsoft.Extensions.Primitives;

namespace Bistrotic.Application.Messages
{
    public interface IMessageFactory
    {
        IMessage GetMessage(string name, string jsonValue);

        IMessage GetMessage(string name, IEnumerable<KeyValuePair<string, StringValues>> values);

        Type GetMessageType(string name);
    }
}