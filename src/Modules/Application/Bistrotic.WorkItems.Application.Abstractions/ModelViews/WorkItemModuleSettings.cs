using System.Collections.Immutable;

using Bistrotic.WorkItems.Application.Models;

namespace Bistrotic.WorkItems.Application.ModelViews
{
    public record WorkItemModuleSettings(
        ImmutableArray<ProjectSla> ProjectSlas,
        string AzureDevOpsServerUrl = "",
        string ClientId = "",
        string ClientSecret = ""
        )
    {
    }
}