namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class Theme : BlazorComponentWithContent
    {
        [Parameter] public string Name { get; set; } = default!;

        public int RenderContent(int sequence, RenderTreeBuilder builder)
        {
            if (ChildContent != null)
            {
                if (string.IsNullOrWhiteSpace(ThemeName))
                {
                    builder.OpenComponent<CascadingValue<string>>(sequence++);
                    builder.AddAttribute(sequence++, "Name", nameof(ThemeName));
                    builder.AddAttribute(sequence++, "Value", Name);
                    builder.AddContent(sequence++, ChildContent);
                    builder.CloseComponent();
                }
            }
            return sequence;
        }

    }
}