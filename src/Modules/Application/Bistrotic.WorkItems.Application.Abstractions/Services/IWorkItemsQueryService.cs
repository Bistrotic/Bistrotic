using System.Collections.Generic;
using System.Threading.Tasks;

using Bistrotic.WorkItems.Application.ModelViews;

namespace Bistrotic.WorkItems.Application.Services
{
    public interface IWorkItemsQueryService
    {
        Task<List<IssueWithSla>> GetIssuesWithSla(bool SuspendedSla = false, bool ClosedIssues = false);

        Task<WorkItemModuleSettings> GetWorkItemModuleSettings();
    }
}