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

    public record Query1 : TestQuery<int>
    {
    }

    public record Query2 : TestQuery<string>
    {
    }

    public record Query3 : TestQuery<Guid>
    {
    }

    public record Query4 : TestQuery<QueryId>
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

    public abstract record TestQuery<T> : Query<T>
    {
        protected TestQuery() : base("test")
        {
        }
    }
}