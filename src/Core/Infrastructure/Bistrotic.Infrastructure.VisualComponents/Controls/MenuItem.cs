using Microsoft.AspNetCore.Components;

namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    public class MenuItem : BlazorComponent
    {
        [Parameter] public bool? Checked { get; set; }
        [Parameter] public bool? Disabled { get; set; }
    }
}