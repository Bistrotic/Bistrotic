using Microsoft.AspNetCore.Components;

namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    public class ApplicationLayout : BlazorComponentWithContent
    {
        private bool _rightToLeft;

        [Parameter]
        public bool RightToLeft
        {
            get => _rightToLeft;
            set
            {
                if (_rightToLeft != value)
                {
                    _rightToLeft = value;
                    StateHasChanged();
                }
            }
        }
    }
}