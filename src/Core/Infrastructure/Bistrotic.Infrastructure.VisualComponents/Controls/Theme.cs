namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class Theme : BlazorComponentWithContent
    {
        private string _name = string.Empty;

        [Parameter]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                ThemeName = _name;
            }
        }

        public override int RenderContent(int sequence, RenderTreeBuilder builder)
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