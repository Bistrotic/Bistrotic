using System;
using System.Diagnostics;

namespace Bistrotic.Infrastructure.CodeGeneration.Attributes
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ApiCommandAttribute : Attribute
    {
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}