using System;
using System.Diagnostics;

namespace Bistrotic.Domain.Contracts.Projections
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class QueryAttribute : Attribute
    {
        private static string GetDebuggerDisplay() => "Query";
    }
}