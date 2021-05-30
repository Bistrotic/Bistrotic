namespace Bistrotic.Infrastructure.VisualComponents.Renderers
{
    using System;
    using System.Collections.Generic;

    public interface IComponentRendererProvider
    {
        IEnumerable<string> ThemeNames { get; }

        IComponentRenderer<TComponent>? GetRenderer<TComponent>(string themeName) where TComponent : BlazorComponent;

        IComponentRenderer? GetRenderer(string themeName, Type componentType);
    }
}