namespace Bistrotic.Infrastructure.VisualComponents.Renderers
{
    using System;
    public interface IComponentRendererProvider
    {
        IComponentRenderer<TComponent>? GetRenderer<TComponent>(string themeName) where TComponent : BlazorComponent;
        IComponentRenderer? GetRenderer(string themeName, Type componentType);
    }
}
