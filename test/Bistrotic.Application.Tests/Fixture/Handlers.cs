namespace Bistrotic.Application.Tests.Fixture
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Bistrotic.Application.Queries;
    using Bistrotic.Application.ValueTypes;

    public class Handlers : Dictionary<Type, Func<IQueryHandler>>
    {
        public Handlers()
        {
            Add(typeof(Query1), () => new QueryHandlerInt());
            Add(typeof(Query2), () => new QueryHandlerString());
            Add(typeof(Query3), () => new QueryHandlerGuid());
            Add(typeof(Query4), () => new QueryHandlerId());
        }
    }

    public abstract class Query<T> : IQuery<T>
    {
        public Query()
        {
            QueryId = new QueryId();
        }

        public QueryId QueryId { get; }
    }

    public class Query1 : Query<int>
    {
    }

    public class Query2 : Query<string>
    {
    }

    public class Query3 : Query<Guid>
    {
    }

    public class Query4 : Query<QueryId>
    {
    }

    public class QueryHandlerGuid : IQueryHandler<Query3, Guid>
    {
        public Task<Guid> Handle(Query3 query)
        {
            return Task.FromResult(new Guid("3"));
        }
    }

    public class QueryHandlerId : IQueryHandler<Query4, QueryId>
    {
        public Task<QueryId> Handle(Query4 query)
        {
            return Task.FromResult(query.QueryId);
        }
    }

    public class QueryHandlerInt : IQueryHandler<Query1, int>
    {
        public Task<int> Handle(Query1 query)
        {
            return Task.FromResult(1);
        }
    }

    public class QueryHandlerString : IQueryHandler<Query2, string>
    {
        public Task<string> Handle(Query2 query)
        {
            return Task.FromResult("2");
        }
    }
}