namespace Bistrotic.Infrastructure.VisualComponents.Renderers.Fluent
{
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    public abstract class FluentComponentRendererBase<TComponent> : ComponentRendererBase<TComponent>
        where TComponent : BlazorComponent
    {
        public FluentComponentRendererBase(string? componentName = null) : base(nameof(Fluent), componentName)
        {
        }
    }
}