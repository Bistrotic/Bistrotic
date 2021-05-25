using System;
using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Renderers
{
    public class ComponentRendererProvider : IComponentRendererProvider
    {
        Dictionary<string, Dictionary<Type, Func<IComponentRenderer>>> _renderers;

        public ComponentRendererProvider(Dictionary<string, Dictionary<Type, Func<IComponentRenderer>>> renderers)
        {
            _renderers = renderers;
        }
        public IComponentRenderer<TComponent>? GetRenderer<TComponent>(string themeName) where TComponent : BlazorComponent
            => (IComponentRenderer<TComponent>?)GetRenderer(themeName, typeof(TComponent));

        public IComponentRenderer? GetRenderer(string themeName, Type componentType)
        {
            if (_renderers.TryGetValue(themeName, out Dictionary<Type, Func<IComponentRenderer>>? theme))
            {
                if (theme.TryGetValue(componentType, out Func<IComponentRenderer>? renderer))
                {
                    return renderer.Invoke();
                }
            }
            return null;
        }
    }
}
