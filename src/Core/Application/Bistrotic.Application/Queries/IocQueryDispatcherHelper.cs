namespace Bistrotic.Application.Queries
{
    using System;

    using Microsoft.Extensions.DependencyInjection;

    public static class IocQueryDispatcherHelper
    {
        public static void AddIocQueryDispatcher(this IServiceCollection services)
        {
            services.AddTransient<IQueryDispatcher>(services => new IocQueryDispatcher(services));
        }

        public static void AddQueryHandler<TQuery, TResult>(this IServiceCollection services, Func<IServiceProvider, IQueryHandler<TQuery, TResult>> handler)
                    where TQuery : class, IQuery<TResult>
        {
            services.AddTransient(handler);
        }
    }
}