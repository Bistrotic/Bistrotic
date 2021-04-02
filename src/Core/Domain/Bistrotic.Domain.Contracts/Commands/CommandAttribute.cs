using System;
using System.Diagnostics;

namespace Bistrotic.Domain.Contracts.Commands
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CommandAttribute : Attribute
    {
        private static string GetDebuggerDisplay() => "Command";
    }
}