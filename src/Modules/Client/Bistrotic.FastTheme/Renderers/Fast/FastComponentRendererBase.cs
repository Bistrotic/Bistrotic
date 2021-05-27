namespace Bistrotic.Infrastructure.VisualComponents.Renderers.Fast
{
    using Bistrotic.Infrastructure.FastTheme.Renderers;
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    public abstract record FastComponentRendererBase<TComponent> : FastAndFluentComponentRendererBase<TComponent>
        where TComponent : BlazorComponent
    {
        public FastComponentRendererBase(string? componentName = null) : base(nameof(Fast), componentName)
        {
        }

        protected FastComponentRendererBase(string themeName, string? componentName = null) : base(themeName, componentName)
        {
        }
    }
}