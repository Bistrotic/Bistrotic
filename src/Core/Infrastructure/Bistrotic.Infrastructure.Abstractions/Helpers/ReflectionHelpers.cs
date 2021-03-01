using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

using Microsoft.Extensions.Primitives;

namespace Bistrotic.Infrastructure.Helpers
{
    public static class ReflectionHelpers
    {
        public static IDictionary<string, object> GetPropertyNotNullValues(this object obj)
            => GetPropertyValues(obj)
                    .Where(p => p.Value != null)
                    .ToDictionary(k => k.Key, v => v.Value ?? throw new NullReferenceException());

        public static IDictionary<string, object?> GetPropertyValues(this object obj) => obj
            .GetType()
            .GetProperties()
            .Where(x => x.CanRead)
            .ToDictionary(x => x.Name, x => x.GetValue(obj, null));

        public static object ToObject(this IEnumerable<KeyValuePair<string, StringValues>> values, Type type)
        {
            object? obj = Activator.CreateInstance(type);
            if (obj == null)
            {
                throw new TypeInitializationException(type.FullName, null);
            }
            foreach (var pair in values)
            {
                if (!StringValues.IsNullOrEmpty(pair.Value))
                {
                    obj.SetValue(pair.Key, pair.Value);
                }
            }
            return obj;
        }

        private static void SetValue(this object obj, string propertyName, string value)
        {
            Type type = obj.GetType() ?? throw new TypeLoadException("The object type can't be retreived.");
            PropertyInfo? property = type.GetProperty(
                propertyName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
                );
            if (property != null)
            {
                property.SetValue(obj, JsonSerializer.Deserialize(value, property.PropertyType));
                return;
            }
            FieldInfo? field = type.GetField(
                propertyName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
                );
            if (field != null)
            {
                field.SetValue(obj, JsonSerializer.Deserialize(value, field.FieldType));
                return;
            }
            throw new KeyNotFoundException($"The property with name '{propertyName}' not found on object type '{type.Name}'.");
        }
    }
}