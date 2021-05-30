namespace Bistrotic.FastTheme.Renderers.Fluent
{
    using Bistrotic.FastTheme.Renderers;

    public sealed record FluentListboxRenderer : ListboxRenderer
    {
        public FluentListboxRenderer() : base(nameof(Fluent))
        {
        }
    }
}