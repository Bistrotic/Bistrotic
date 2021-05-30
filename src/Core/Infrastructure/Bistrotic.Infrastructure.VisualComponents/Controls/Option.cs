using Microsoft.AspNetCore.Components;

namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
#pragma warning disable CA1716 // Identifiers should not match keywords

    public class Option : BlazorComponent
    {
        [Parameter] public bool? Disabled { get; set; }

        [Parameter] public bool? Selected { get; set; }
        [Parameter] public string Value { get; set; } = string.Empty;
    }
}