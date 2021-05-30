namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class Theme : BlazorComponent
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
                this.StateHasChanged();
            }
        }

        public override int RenderContent(int sequence, RenderTreeBuilder builder)
        {
            if (ChildContent != null && !string.IsNullOrWhiteSpace(ThemeName))
            {
                builder.OpenComponent<CascadingValue<string>>(sequence++);
                builder.AddAttribute(sequence++, "Name", nameof(ThemeName));
                builder.AddAttribute(sequence++, "Value", Name);
                builder.AddAttribute(sequence++, "ChildContent", ChildContent);
                builder.CloseComponent();
            }
            return sequence;
        }
    }
}