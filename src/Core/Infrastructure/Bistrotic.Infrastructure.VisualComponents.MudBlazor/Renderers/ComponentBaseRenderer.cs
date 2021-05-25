namespace Bistrotic.Infrastructure.VisualComponents.MudBlazor.Renderers
{
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public abstract class ComponentBaseRenderer<TComponent, TMud> : IComponentRenderer<TComponent>
        where TComponent : BlazorComponent
        where TMud : ComponentBase
    {

        public virtual int Render(int sequence, BlazorComponent blazorComponent, RenderTreeBuilder builder)
        {
            builder.OpenComponent(sequence++, typeof(TMud));
            sequence = RenderAttributes(sequence, blazorComponent, builder);
            sequence = RenderContent(sequence, blazorComponent, builder);
            builder.CloseComponent();
            return sequence;
        }

        public virtual int RenderAttributes(int sequence, BlazorComponent blazorComponent, RenderTreeBuilder builder)
        {
            builder.AddMultipleAttributes(sequence++, blazorComponent.AdditionalAttributes);
            return sequence;
        }

        public virtual int RenderContent(int sequence, BlazorComponent blazorComponent, RenderTreeBuilder builder)
        {
            return sequence;
        }

        public void BuildRenderTree(BlazorComponent blazorComponent, RenderTreeBuilder builder)
        {
            Render(0, blazorComponent, builder);
        }

        public string ThemeName => nameof(MudBlazor);
    }
}