namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class BadgeRenderer : ComponentRenderer<Badge, MudBadge>
    {
        public BadgeRenderer(Badge component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}