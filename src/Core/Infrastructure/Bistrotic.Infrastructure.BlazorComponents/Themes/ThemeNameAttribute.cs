namespace Bistrotic.Infrastructure.BlazorComponents.Themes
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ThemeNameAttribute : Attribute
    {
        public ThemeNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}