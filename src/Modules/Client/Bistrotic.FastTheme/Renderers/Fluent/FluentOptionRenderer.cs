namespace Bistrotic.FastTheme.Renderers.Fluent
{
    using Bistrotic.FastTheme.Renderers;

    public sealed record FluentOptionRenderer : OptionRenderer
    {
        public FluentOptionRenderer() : base(nameof(Fluent))
        {
        }
    }
}