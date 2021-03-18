namespace Bistrotic.Identity
{
 
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;


    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    
    public sealed class IdentityModule : ServerModule
    {
        private readonly IdentitySettings _settings;

        public IdentityModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(moduleDefinition, configuration, environment, clientMode)
        {
            _settings = configuration.GetSettings<IdentitySettings>();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);
            if (env.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetUserDetails).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SecurityDbContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(Configuration.GetConnectionString(nameof(OpenIdDict)),
                    x => x.MigrationsAssembly(typeof(SecurityDbContext).Assembly.GetName().Name));

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need to replace the default OpenIddict entities.
                options.UseOpenIddict();
            });

            if (Environment.IsDevelopment())
            {
                services.AddDatabaseDeveloperPageExceptionFilter();
            }

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders();
        }

     }
}