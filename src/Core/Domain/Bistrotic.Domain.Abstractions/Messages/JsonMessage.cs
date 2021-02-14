using System;
using System.Text.Json;

namespace Bistrotic.Domain.Messages
{
    public sealed class JsonMessage
    {
        [Obsolete("For serializers only")]
        public JsonMessage()
        {
            AssemblyQualifiedName = JsonValue = string.Empty;
        }

        public JsonMessage(string assemblyQualifiedName, string jsonValue)
        {
            AssemblyQualifiedName = assemblyQualifiedName;
            JsonValue = jsonValue;
        }

        public JsonMessage(Type type, string jsonValue)
        {
            AssemblyQualifiedName = type.AssemblyQualifiedName ?? throw new ArgumentException($"The type '{type.Name}' does not have an assembly name.", nameof(type));
            JsonValue = jsonValue;
        }

        public string AssemblyQualifiedName { get; }

        public string JsonValue { get; }

        public static JsonMessage New<TMessage>(TMessage message) => new JsonMessage(typeof(TMessage), JsonSerializer.Serialize(message));

        public IMessage GetMessage()
                    => JsonSerializer.Deserialize(
                JsonValue,
                Type.GetType(AssemblyQualifiedName)
                    ?? throw new Exception($"The type with assembly qualified name '{AssemblyQualifiedName}', not found.")) as IMessage
            ?? throw new Exception($"Can't deserialize object '{AssemblyQualifiedName}' with value : {JsonValue}");
    }
}