using Bistrotic.Application.Queries;
using Bistrotic.Roles.Application.ModelViews;

namespace Bistrotic.Roles.Application.Queries
{
    public sealed class GetRoleSummaryInformationsList
        : QueryBase<RoleSummaryInformations[]>
    {
        public GetRoleSummaryInformationsList(int take = 0, int skip = 0)
        {
            Take = take;
            Skip = skip;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}