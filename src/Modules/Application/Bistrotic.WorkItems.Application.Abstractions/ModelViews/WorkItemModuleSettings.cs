namespace Bistrotic.WorkItems.Application.Abstractions.ModelViews
{
    public record WorkItemModuleSettings(
        string AzureDevOpsServerUrl = "",
        string ClientId = "",
        string ClientSecret = ""
        )
    {
    }
}