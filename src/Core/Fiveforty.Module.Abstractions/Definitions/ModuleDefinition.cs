namespace Fiveforty.Module.Definitions
{
    using System;
    using System.Linq;

    public record ModuleDefinition
    {
        public ModuleDefinition(string name, string typeName, string? normalizedName = null, string[]? dependencies = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name not defined.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new ArgumentException("Module type name not defined.", nameof(typeName));
            }
            Name = name;
            TypeName = typeName;
            NormalizedName = NormalizeName(string.IsNullOrWhiteSpace(normalizedName) ? Name : normalizedName);
            if (dependencies == null || !dependencies.Any())
            {
                Dependencies = Array.Empty<string>();
            }
            else
            {
                Dependencies = dependencies.Select(p => NormalizeName(p)).ToArray();
            }
        }

        public string Name { get; }
        public string TypeName { get; }
        public string NormalizedName { get; }

        private static string NormalizeName(string name)
            => name.Trim().ToLowerInvariant().Replace(' ', '_');

        public string Description { get; init; } = string.Empty;
        public string Version { get; init; } = "1.0.0";
        public string[] Dependencies { get; }
        public int Priority { get; init; } = 0;
        public bool Enabled { get; init; } = true;
    }
}