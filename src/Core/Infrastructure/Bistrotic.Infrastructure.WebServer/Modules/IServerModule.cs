﻿using Bistrotic.Infrastructure.Modules;

using Microsoft.Extensions.DependencyInjection;

namespace Bistrotic.Infrastructure.WebServer.Modules
{
    public interface IServerModule : IModule
    {
        void ConfigureServices(IServiceCollection services);
    }
}