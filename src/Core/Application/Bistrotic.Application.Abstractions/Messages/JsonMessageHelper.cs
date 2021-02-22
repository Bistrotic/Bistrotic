namespace Bistrotic.Application
{
    using System;
    using System.Text.Json;

    using Bistrotic.Application.Exceptions;
    using Bistrotic.Domain.Messages;

    public static class JsonMessageHelper
    {
        public static IMessage CreateMessageFromJson(this string json, Type messageType)
            => (JsonSerializer.Deserialize(json, messageType) as IMessage) ?? throw new InvalidMessageException(messageType, json);

        public static IMessage CreateMessageFromJson(this Type messageType, string json)
            => (JsonSerializer.Deserialize(json, messageType) as IMessage) ?? throw new InvalidMessageException(messageType, json);

        public static string Json(this IMessage message)
            => JsonSerializer.Serialize(message, message.GetType());
    }
}