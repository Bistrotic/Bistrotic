namespace Bistrotic.Infrastructure.VisualComponents.Renderers
{

    using Bistrotic.Infrastructure.VisualComponents.Controls;
    using Bistrotic.Infrastructure.VisualComponents.MudBlazor.Renderers;

    using global::MudBlazor;

    using Microsoft.AspNetCore.Components.Rendering;

    public sealed record ThemeRenderer : ComponentBaseRenderer<Theme, MudThemeProvider>
    {
        public override int Render(int sequence, BlazorComponent blazorComponent, RenderTreeBuilder builder)
        {
            builder.OpenElement(sequence++, "link");
            builder.AddAttribute(sequence++, "href", "_content/MudBlazor/MudBlazor.min.css");
            builder.AddAttribute(sequence++, "rel", "stylesheet");
            builder.CloseElement();
            builder.OpenElement(sequence++, "link");
            builder.AddAttribute(sequence++, "href", "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap");
            builder.AddAttribute(sequence++, "rel", "stylesheet");
            builder.CloseElement();
            builder.OpenComponent(sequence++, typeof(MudThemeProvider));
            builder.CloseComponent();
            builder.OpenComponent(sequence++, typeof(MudDialogProvider));
            builder.CloseComponent();
            builder.OpenComponent(sequence++, typeof(MudSnackbarProvider));
            builder.CloseComponent();
            sequence = ((Theme)blazorComponent).RenderContent(sequence++, builder);
            builder.OpenElement(sequence++, "script");
            builder.AddAttribute(sequence++, "src", "_content/MudBlazor/MudBlazor.min.js");
            builder.AddAttribute(sequence++, "type", "text/javascript");
            builder.CloseElement();
            return sequence;
        }
    }
}
