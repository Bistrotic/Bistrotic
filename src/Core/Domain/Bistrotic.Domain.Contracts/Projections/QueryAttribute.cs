namespace Bistrotic.Domain.Contracts.Projections
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class QueryAttribute : Attribute
    {
        private static string GetDebuggerDisplay() => "Query";
    }
}