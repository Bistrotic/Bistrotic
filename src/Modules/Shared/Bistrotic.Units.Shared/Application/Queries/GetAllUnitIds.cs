namespace Bistrotic.Units.Application.Queries
{
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;

    public sealed class GetAllUnitIds : Query<List<int>>
    {
        public GetAllUnitIds(int take, int skip)
        {
            Take = take;
            Skip = skip;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}