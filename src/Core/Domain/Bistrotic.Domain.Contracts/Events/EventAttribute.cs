using System;
using System.Diagnostics;

namespace Bistrotic.Domain.Contracts.Events
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EventAttribute : Attribute
    {
        private static string GetDebuggerDisplay() => "Event";
    }
}