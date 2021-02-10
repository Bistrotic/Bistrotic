namespace Bistrotic.Infrastructure.WebServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure.Modules;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Models;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public abstract class ServerStartup<TDbContext>
        where TDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly IWebHostEnvironment _environment;

        private IEnumerable<IServerModule>? _serverModules;

        protected ServerStartup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        protected IEnumerable<IServerModule> ServerModules => _serverModules ??= GetServerModules();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bistrotic V1"));
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            ConfigureSecurity(services);
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews().AddDapr();
            services.AddRazorPages();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bistrotic", Version = "v1" }));
            ConfigureModules(services);
        }

        protected virtual void ConfigureModules(IServiceCollection services)
        {
            IMvcBuilder mvcBuilder = services.AddControllers();
            foreach (IServerModule module in ServerModules)
            {
                module.ConfigureServices(services);
                mvcBuilder.AddApplicationPart(module.GetType().Assembly);
            }
        }

        protected virtual void ConfigureSecurity(IServiceCollection services)
        {
            services.AddDbContext<TDbContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<TDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, TDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
        }

        protected Task HandleApiFallback(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return Task.FromResult(0);
        }

        private IEnumerable<IServerModule> GetServerModules()
        {
            var modules = new ModuleFactory(
                new Func<IModuleDefinitionLoader>[] { () => new ReflectionServerModuleDefinitionLoader() },
                new Func<IModuleActivator>[] { () => new ReflectionServerModuleActivator(Configuration, _environment) });
            return modules.GetModules()
                .GetAwaiter()
                .GetResult()
                .OfType<IServerModule>()
                .Select(p => p);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    }
}