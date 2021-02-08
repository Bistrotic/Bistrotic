namespace Bistrotic.WorkItems.Application.ModelViews
{
    public record WorkItemModuleSettings(
        string AzureDevOpsServerUrl = "",
        string ClientId = "",
        string ClientSecret = ""
        )
    {
    }
}