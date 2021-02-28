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

        /// <summary>
        /// Set a private Property Value on a given Object. Uses Reflection.
        /// </summary>
        /// <param name="obj">Object from where the Property Value is returned</param>
        /// <param name="propName">Propertyname as string.</param>
        /// <param name="val">the value to set</param>
        /// <exception cref="ArgumentOutOfRangeException">if the Property is not found</exception>
        public static void SetPrivateFieldValue(this object obj, string propName, object val)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            Type? t = obj.GetType();
            FieldInfo? fi = null;
            while (fi == null && t != null)
            {
                fi = t.GetField(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                t = t.BaseType;
            }
            if (fi == null) throw new ArgumentOutOfRangeException("propName", $"Field {propName} was not found in Type {obj.GetType().FullName}");
            fi.SetValue(obj, val);
        }

        public static object ToObject(this IEnumerable<KeyValuePair<string, StringValues>> values, Type type)
        {
            object? obj = Activator.CreateInstance(type);
            if (property == null)
            {
                throw new KeyNotFoundException($"The property with name '{pair.Key}' not found on object type '{type.Name}'.");
            }
            if (obj == null)
            {
                throw new TypeInitializationException(type.FullName, null);
            }
            foreach (var pair in values)
            {
                if (!StringValues.IsNullOrEmpty(pair.Value))
                {
                    property.SetValue(obj, JsonSerializer.Deserialize(pair.Value, property.PropertyType), BindingFlags.NonPublic, null, null, null);
                }
            }
            return obj;
        }
    }
}