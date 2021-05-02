namespace Bistrotic.Domain.ValueTypes
{
    using System.Diagnostics;
    using System.Text.Json.Serialization;

    [DebuggerDisplay("{Value}")]
    public abstract class SingleValueType<T>
    {
        protected SingleValueType(SingleValueType<T> value)
        {
            Value = value.Value;
        }

        protected SingleValueType(T value)
        {
            Value = value;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8601 // Possible null reference assignment.

        // For serializers
        protected SingleValueType()
        {
            Value = default;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8601 // Possible null reference assignment.

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public T Value { get; init; }

        public static implicit operator T(SingleValueType<T> value) => value.Value;

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var objValue = ((SingleValueType<T>)obj).Value;
            if (Value == null)
            {
                return objValue == null;
            }

            return Value.Equals(objValue);
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        public override string ToString() => Value?.ToString() ?? string.Empty;
    }
}