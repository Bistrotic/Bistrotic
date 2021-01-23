namespace Fiveforty.Module
{
    public record ModuleDefinition(string Name, string TypeName)
    {
        public string Description { get; init; } = string.Empty;
        public string Version { get; init; } = "1.0.0";
        public string Dependencies { get; init; } = string.Empty;
        public int Priority { get; init; } = 0;
        public bool Enabled { get; init; } = true;
    }
}