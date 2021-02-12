namespace Bistrotic.Application.Queries
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    public interface IQueryHandler
    {
        public bool CanHandle(Type queryType);

        Task<object?> Handle(IEnvelope query);
    }

    public interface IQueryHandler<TQuery, TResult> : IQueryHandler
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(Envelope<TQuery> query);
    }
}