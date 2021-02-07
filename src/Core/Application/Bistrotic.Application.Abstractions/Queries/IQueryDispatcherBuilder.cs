namespace Bistrotic.Application.Queries
{
    using System;

    public interface IQueryDispatcherBuilder
    {
        IQueryDispatcherBuilder AddQueryHandler<TQuery, TResult>(Func<IQueryHandler<TQuery, TResult>> handler)
            where TQuery : IQuery<TResult>;

        IQueryDispatcher Build();
    }
}