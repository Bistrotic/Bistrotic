using System;
using System.Diagnostics;

namespace Bistrotic.Application.Queries
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ApiQueryAttribute : Attribute
    {
        private static string GetDebuggerDisplay() => "ApiQuery";
    }
}