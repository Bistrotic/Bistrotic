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
        protected Query()
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

    public class QueryHandlerGuid : QueryHandler<Query3, Guid>
    {
        public override Task<Guid> Handle(Query3 query)
        {
            return Task.FromResult(new Guid("3"));
        }
    }

    public class QueryHandlerId : QueryHandler<Query4, QueryId>
    {
        public override Task<QueryId> Handle(Query4 query)
        {
            return Task.FromResult(query.QueryId);
        }
    }

    public class QueryHandlerInt : QueryHandler<Query1, int>
    {
        public override Task<int> Handle(Query1 query)
        {
            return Task.FromResult(1);
        }
    }

    public class QueryHandlerString : QueryHandler<Query2, string>
    {
        public override Task<string> Handle(Query2 query)
        {
            return Task.FromResult("2");
        }
    }
}