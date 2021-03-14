﻿using System.Collections.Generic;

using Bistrotic.Application.Queries;

namespace Bistrotic.Users.Application.Queries
{
    [ApiQuery(typeof(List<int>))]
    public sealed record GetAllUserIds
    {
        public GetAllUserIds()
        {
        }
        public GetAllUserIds(int take, int skip)
        {
            Take = take;
            Skip = skip;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}