namespace Fiveforty.Module.Definitions
{
    public interface IModuleDefinition
    {
        string[] Dependencies { get; }
        string Description { get; }
        bool Enabled { get; }
        string Name { get; }
        string NormalizedName { get; }
        int Priority { get; }
        string TypeName { get; }
        string Version { get; }
    }
}