namespace Bistrotic.Infrastructure.WebServer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using Bistrotic.Application.Queries;
    using Bistrotic.Infrastructure.WebServer.Controllers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    public abstract class ServerProgram
    {
        private readonly string[] _args;

        private IHostBuilder? _hostBuilder;
        private Dictionary<Type, Func<IConfiguration, IWebHostEnvironment, IServerModule>>? _modules;

        protected ServerProgram(string[] args)
        {
            _args = args;
        }

        public IHostBuilder HostBuilder => _hostBuilder ??= CreateHostBuilder();
        private Dictionary<Type, Func<IConfiguration, IWebHostEnvironment, IServerModule>> Modules => _modules ??= InitializeModules();

        public virtual void Configure(IApplicationBuilder app, WebHostBuilderContext context)
        {
        }

        public IHostBuilder CreateHostBuilder()
                    => Host
                .CreateDefaultBuilder(_args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.ConfigureAppConfiguration(config => config.AddUserSecrets(GetType().Assembly));
                    builder.ConfigureServices((context, services) =>
                    {
                        context.HostingEnvironment.ApplicationName = GetType().Assembly.GetName().Name;
                        ConfigureServices(services);
                        services.AddTransient<IQueryDispatcher, IocQueryDispatcher>();
                        services.AddControllersWithViews();
                        var mvc = services
                            .AddRazorPages()
                            .AddApplicationPart(typeof(QueryCommandController).Assembly)
                            .AddApplicationPart(GetType().Assembly)
                            .AddDapr();
                        services.AddServerSideBlazor();
                        services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bistrotic", Version = "v1" }));
                        foreach (var modulePair in Modules)
                        {
                            IServerModule module = modulePair
                                .Value(context.Configuration, context.HostingEnvironment);
                            module.ConfigureServices(services);
                            services.AddSingleton(module);
                            mvc.AddApplicationPart(modulePair.Key.Assembly);
                        }
                    });
                    builder.ConfigureLogging(l => l.AddAzureWebAppDiagnostics());
                    builder.Configure((context, app) =>
                    {
                        context.HostingEnvironment.ApplicationName = GetType().Assembly.GetName().Name;
                        Configure(app, context);
                        foreach (var module in Modules)
                        {
                            module
                                .Value(context.Configuration, context.HostingEnvironment)
                                .Configure(app, context.HostingEnvironment);
                        }
                        if (context.HostingEnvironment.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseWebAssemblyDebugging();
                        }
                        else
                        {
                            app.UseExceptionHandler("/Error");
                            // The default HSTS value is 30 days. You may want to change this for
                            // production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                            endpoints.Map("api/{**slug}", HandleApiFallback);
                            endpoints.MapRazorPages();
                            endpoints.MapFallbackToPage("/_Host");
                        });
                    });
                    builder.CaptureStartupErrors(true);
                    builder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                    builder.UseContentRoot(Directory.GetCurrentDirectory());
                });

        public virtual Dictionary<Type, Func<IConfiguration, IWebHostEnvironment, IServerModule>> InitializeModules()
                    => new();

        protected static Task HandleApiFallback(HttpContext context)
        {
            // Calling an API that does not exist.
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return Task.CompletedTask;
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
        }
    }
}