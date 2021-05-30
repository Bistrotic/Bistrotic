namespace Bistrotic.FastTheme.Renderers.Fluent
{
    public sealed record FluentThemeRenderer : ThemeRenderer
    {
        public FluentThemeRenderer() : base(nameof(Fluent), "https://unpkg.com/@fluentui/web-components")
        {
        }
    }
}