namespace Bistrotic.FastTheme.Renderers.Fast
{
    public sealed record FastThemeRenderer : ThemeRenderer
    {
        public FastThemeRenderer() : base(nameof(Fast), "https://unpkg.com/@microsoft/fast-components")
        {
        }
    }
}