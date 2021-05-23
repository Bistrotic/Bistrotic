using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    public class Anchor : BlazorComponent
    {
        /// <summary>
        /// If true, the button will be disabled.
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// Button click event.
        /// </summary>
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}