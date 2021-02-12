namespace Bistrotic.Application.Tests.Fixture
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;

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

    public sealed class Query1 : TestQuery<int>
    {
    }

    public sealed class Query2 : TestQuery<string>
    {
    }

    public sealed class Query3 : TestQuery<Guid>
    {
    }

    public sealed class Query4 : TestQuery<MessageId>
    {
    }

    public class QueryHandlerGuid : QueryHandler<Query3, Guid>
    {
        public override Task<Guid> Handle(Envelope<Query3> query)
        {
            return Task.FromResult(new Guid("3"));
        }
    }

    public class QueryHandlerId : QueryHandler<Query4, MessageId>
    {
        public override Task<MessageId> Handle(Envelope<Query4> query)
        {
            return Task.FromResult(query.Message.MessageId);
        }
    }

    public class QueryHandlerInt : QueryHandler<Query1, int>
    {
        public override Task<int> Handle(Envelope<Query1> query)
        {
            return Task.FromResult(1);
        }
    }

    public class QueryHandlerString : QueryHandler<Query2, string>
    {
        public override Task<string> Handle(Envelope<Query2> query)
        {
            return Task.FromResult("2");
        }
    }

    public abstract class TestQuery<TResult> : Query<TResult>
    {
    }
}