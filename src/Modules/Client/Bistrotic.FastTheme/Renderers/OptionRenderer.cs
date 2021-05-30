namespace Bistrotic.FastTheme.Renderers
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    public abstract record OptionRenderer : FastAndFluentComponentRendererBase<Option>
    {
        public OptionRenderer(string themeName) : base(themeName)
        {
        }
    }
}