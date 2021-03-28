namespace Bistrotic.Infrastructure.WebServer
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Bistrotic.Application.Queries;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

#pragma warning disable CA2201 // Do not raise reserved exception types

    public abstract class ServerStartup
    {
        private readonly IWebHostEnvironment _environment;
        private IEnumerable<IServerModule>? _modules;

        protected ServerStartup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            Configuration = configuration;
            ClientMode = configuration.GetSection(nameof(ClientMode)).Get<ClientMode>();
        }

        public ClientMode ClientMode { get; }
        public IConfiguration Configuration { get; }
        protected IEnumerable<IServerModule> Modules => _modules ?? throw new NullReferenceException("Modules are not initialized.");

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env, IEnumerable<IServerModule> modules)
        {
            _modules = modules;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production
                // scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseBlazorFrameworkFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bistrotic V1"));
            foreach (IServerModule module in _modules)
            {
                module.Configure(app, env);
            }
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IQueryDispatcher, IocQueryDispatcher>();
            services
                .AddMvc()
                .AddDapr();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bistrotic", Version = "v1" }));
        }

        public virtual void OnStarted()
        {
            foreach (IServerModule module in Modules)
            {
                module.OnStarted();
            }
            /* Perform post-startup activities here
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var modules = scope.ServiceProvider.GetRequiredService<IEnumerable<IServerModule>>();
                try
                {
                    await Task
                        .WhenAll(modules.Select(p => p.OnStartup(services)).ToArray())
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    services
                        .GetRequiredService<ILogger<TStartup>>()
                        .LogError(ex, "An error occurred while initializing modules.");
                }
            }
            return host;
            */
        }

        public virtual void OnStopped()
        {
            foreach (IServerModule module in Modules)
            {
                module.OnStopped();
            }
        }

        public virtual void OnStopping()
        {
            foreach (IServerModule module in Modules)
            {
                module.OnStopping();
            }
        }

        protected static Task HandleApiFallback(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return Task.FromResult(0);
        }

        /*
        protected virtual void ConfigureModules(IServiceCollection services)
        {
            IMessageFactoryBuilder messageBuilder = new InMemoryMessageFactoryBuilder();
            foreach (IServerModule module in ServerModules)
            {
                module.ConfigureServices(services);
                module.ConfigureMessages(messageBuilder);
                mvcBuilder.AddApplicationPart(module.GetType().Assembly);
            }
            services.AddSingleton(messageBuilder.Build());
        }

        private IEnumerable<IServerModule> GetServerModules()
        {
            var modules = new ModuleFactory(
                new Func<IModuleDefinitionLoader>[] { () => new ReflectionServerModuleDefinitionLoader() },
                new Func<IModuleActivator>[] { () => new ReflectionServerModuleActivator(Configuration, _environment, ClientMode) });
            return modules.GetModules()
                .GetAwaiter()
                .GetResult()
                .Cast<IServerModule>();
        }
        */
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    }
}