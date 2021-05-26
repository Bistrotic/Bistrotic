using System;

using Microsoft.AspNetCore.Components.Rendering;

namespace Bistrotic.Infrastructure.VisualComponents.Renderers
{
    public interface IComponentRenderer
    {
        void BuildRenderTree(BlazorComponent blazorComponent, RenderTreeBuilder builder);
        public string ThemeName { get; }
        public Type ControlType { get; }
    }
    public interface IComponentRenderer<TComponent> : IComponentRenderer
        where TComponent : BlazorComponent
    {
    }
}
