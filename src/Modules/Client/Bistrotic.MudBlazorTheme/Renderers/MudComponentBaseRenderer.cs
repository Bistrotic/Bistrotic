namespace Bistrotic.Infrastructure.VisualComponents.MudBlazor.Renderers
{
    using global::MudBlazor;

    using Microsoft.AspNetCore.Components.Rendering;

    public abstract record MudComponentBaseRenderer<TComponent, TMud> : ComponentBaseRenderer<TComponent, TMud>
        where TComponent : BlazorComponent
        where TMud : MudComponentBase
    {
        public override int RenderAttributes(int sequence, BlazorComponent blazorComponent, RenderTreeBuilder builder)
        {
            builder.AddAttribute(sequence++, nameof(MudComponentBase.Class), string.Join(' ', blazorComponent.Classes));
            builder.AddAttribute(sequence++, nameof(MudComponentBase.Style), blazorComponent.AdditionalStyles);
            builder.AddAttribute(sequence++, nameof(MudComponentBase.Tag), blazorComponent.Tag);
            return base.RenderAttributes(sequence++, blazorComponent, builder);
        }
    }
}