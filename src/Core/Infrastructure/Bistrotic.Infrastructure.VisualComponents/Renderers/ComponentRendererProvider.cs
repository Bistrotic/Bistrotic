using System;
using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Renderers
{
    public class ComponentRendererProvider : Dictionary<Type, Func<IComponentRenderer>>, IComponentRendererProvider
    {
        public ComponentRendererProvider(Dictionary<Type, Func<IComponentRenderer>> renderers)
        {

        }
        public IComponentRenderer<TComponent>? GetRenderer<TComponent>() where TComponent : BlazorComponent
            => (IComponentRenderer<TComponent>?)GetRenderer(typeof(TComponent));

        public IComponentRenderer? GetRenderer(Type componentType)
        {
            TryGetValue(componentType, out Func<IComponentRenderer>? renderer);
            return renderer?.Invoke();
        }
    }
}           
  