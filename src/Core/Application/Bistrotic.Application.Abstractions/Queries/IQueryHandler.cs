using System;
using System.Threading.Tasks;

namespace Bistrotic.Application.Queries
{
    public interface IQueryHandler
    {
        public bool CanHandle(Type queryType);

        Task<object?> Handle(IQuery query);
    }

    public interface IQueryHandler<in TQuery, TResult> : IQueryHandler
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}