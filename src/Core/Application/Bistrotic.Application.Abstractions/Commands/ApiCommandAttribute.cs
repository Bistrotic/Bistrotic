using System;
using System.Diagnostics;

namespace Bistrotic.Application.Commands
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ApiCommandAttribute : Attribute
    {
        private static string GetDebuggerDisplay() => "ApiCommand";
    }
}