namespace Bistrotic.FastTheme.Renderers
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    public record ListboxRenderer : FastAndFluentComponentRendererBase<Listbox>
    {
        public ListboxRenderer(string themeName) : base(themeName)
        {
        }
    }
}