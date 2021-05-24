namespace Bistrotic.Infrastructure.VisualComponents.Renderers.Fast
{
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    public abstract class FastComponentRendererBase<TComponent> : ComponentRendererBase<TComponent>
        where TComponent : BlazorComponent
    {
        public FastComponentRendererBase(string? componentName = null) : base(nameof(Fast), componentName)
        {
        }
    }
}