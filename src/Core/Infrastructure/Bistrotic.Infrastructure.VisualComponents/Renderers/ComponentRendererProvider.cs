using System;
using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Renderers
{
    public class ComponentRendererProvider : IComponentRendererProvider
    {
        private readonly Dictionary<string, Dictionary<Type, IComponentRenderer>> _renderers;

        public ComponentRendererProvider(IEnumerable<IComponentRenderer> renderers)
        {
            _renderers = new();
            foreach (var renderer in renderers)
            {
                if (!_renderers.TryGetValue(renderer.ThemeName, out var theme))
                {
                    theme = new();
                    _renderers.Add(renderer.ThemeName, theme);
                }
                theme.Add(renderer.ControlType, renderer);
            }
        }

        public IComponentRenderer<TComponent>? GetRenderer<TComponent>(string themeName) where TComponent : BlazorComponent
            => (IComponentRenderer<TComponent>?)GetRenderer(themeName, typeof(TComponent));

        public IComponentRenderer? GetRenderer(string themeName, Type componentType)
        {
            if (_renderers.TryGetValue(themeName, out Dictionary<Type, IComponentRenderer>? theme))
            {
                if (theme.TryGetValue(componentType, out IComponentRenderer? renderer))
                {
                    return renderer;
                }
            }
            return null;
        }
    }
}