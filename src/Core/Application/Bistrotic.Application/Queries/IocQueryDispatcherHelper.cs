namespace Bistrotic.Application.Queries
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Extensions.DependencyInjection;

    public static class IocQueryDispatcherHelper
    {
        public static void AddIocQueryDispatcher(this IServiceCollection services)
        {
            services.AddTransient<IQueryDispatcher>(services => new IocQueryDispatcher(services));
        }

        public static void AddQueryHandler<TQuery, TResult>(this IServiceCollection services, Func<IServiceProvider, IQueryHandler<TQuery, TResult>> handler)
                    where TQuery : IQuery<TResult>
        {
            services.AddTransient(handler);
        }
    }
}