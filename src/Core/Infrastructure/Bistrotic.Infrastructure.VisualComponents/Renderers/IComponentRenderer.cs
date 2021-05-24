using Microsoft.AspNetCore.Components.Rendering;

namespace Bistrotic.Infrastructure.VisualComponents.Renderers
{
    public interface IComponentRenderer
    {
        void BuildRenderTree(BlazorComponent blazorComponent, RenderTreeBuilder builder);
    }
    public interface IComponentRenderer<TComponent> : IComponentRenderer
        where TComponent : BlazorComponent
    {
        public string ThemeName { get; }
    }
}
