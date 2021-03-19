namespace Bistrotic.Roles.Application.Queries
{
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;

    public sealed class GetAllRoleIds : QueryBase<List<int>>
    {
        public GetAllRoleIds(int take, int skip)
        {
            Take = take;
            Skip = skip;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}