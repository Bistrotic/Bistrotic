namespace Bistrotic.OpenIdDict
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.OpenIdDict.Application.Queries;
    using Bistrotic.OpenIdDict.Data;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using OpenIddict.Abstractions;

    using static OpenIddict.Abstractions.OpenIddictConstants;

    public sealed class OpenIdDictServerModule : ServerModule
    {
        public OpenIdDictServerModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(moduleDefinition, configuration, environment, clientMode)
        {
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
                options.UseSqlServer(Configuration.GetConnectionString(nameof(OpenIdDict)));

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need to replace the default OpenIddict entities.
                options.UseOpenIddict();
            });

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity to use the same JWT claims as OpenIddict instead of the legacy
            // WS-Federation claims it uses by default (ClaimTypes), which saves you from doing the
            // mapping in your authorization controller.
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = Claims.Role;
            });

            services.AddOpenIddict()

                // Register the OpenIddict core components.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.
                    options.UseEntityFrameworkCore()
                           .UseDbContext<SecurityDbContext>();
                })

                // Register the OpenIddict server components.
                .AddServer(options =>
                {
                    // Enable the authorization, logout, token and userinfo endpoints.
                    options.SetAuthorizationEndpointUris("/connect/authorize")
                           .SetLogoutEndpointUris("/connect/logout")
                           .SetTokenEndpointUris("/connect/token")
                           .SetUserinfoEndpointUris("/connect/userinfo");

                    // Mark the "email", "profile" and "roles" scopes as supported scopes.
                    options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles);

                    // Note: the sample uses the code and refresh token flows but you can enable the
                    // other flows if you need to support implicit, password or client credentials.
                    options.AllowAuthorizationCodeFlow()
                           .AllowRefreshTokenFlow();

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate()
                           .AddDevelopmentSigningCertificate();

                    // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                    options.UseAspNetCore()
                           .EnableAuthorizationEndpointPassthrough()
                           .EnableLogoutEndpointPassthrough()
                           .EnableStatusCodePagesIntegration()
                           .EnableTokenEndpointPassthrough();
                })

                // Register the OpenIddict validation components.
                .AddValidation(options =>
                {
                    // Import the configuration from the local OpenIddict server instance.
                    options.UseLocalServer();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                });
        }

        public override async Task StartAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<SecurityDbContext>();
            await context.Database.EnsureCreatedAsync(cancellationToken);
            if (!Environment.IsDevelopment())
                return;
            var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

            if (await manager.FindByClientIdAsync("bistrotic-client", cancellationToken) is null)
            {
#pragma warning disable S1075 // URIs should not be hardcoded
                const string debugUrl = "https://localhost:5001/authentication/";
#pragma warning restore S1075 // URIs should not be hardcoded
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "bistrotic-client",
                    ConsentType = ConsentTypes.Explicit,
                    DisplayName = "Bistrotic client application",
                    Type = ClientTypes.Public,
                    PostLogoutRedirectUris =
                    {
                        new Uri(debugUrl+"logout-callback")
                    },
                    RedirectUris =
                    {
                        new Uri(debugUrl+"login-callback")
                    },
                    Permissions =
                    {
                        Permissions.Endpoints.Authorization,
                        Permissions.Endpoints.Logout,
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.AuthorizationCode,
                        Permissions.GrantTypes.RefreshToken,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles
                    },
                    Requirements =
                    {
                        Requirements.Features.ProofKeyForCodeExchange
                    }
                }, cancellationToken);
            }
        }
    }

#pragma warning disable S125 // Sections of code should not be commented out
    /*
            protected virtual void ConfigureSecurityServices(IServiceCollection services)
            {
                services.AddDbContext<TDbContext>(options =>
                {
                    // Configure the context to use Microsoft SQL Server.
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                    // Register the entity sets needed by OpenIddict.
                    // Note: use the generic overload if you need to replace the default OpenIddict entities.
                    options.UseOpenIddict();
                });

                services.AddOpenIddict()

                  // Register the OpenIddict core components.
                  .AddCore(options =>
                  {
                      // Configure OpenIddict to use the Entity Framework Core stores and models.
                      // Note: call ReplaceDefaultEntities() to replace the default entities.
                      options.UseEntityFrameworkCore()
                                   .UseDbContext<TDbContext>();
                  })

                  // Register the OpenIddict server components.
                  .AddServer(options =>
                  {
                      // Enable the token endpoint.
                      options.SetTokenEndpointUris("/connect/token");

                      // Enable the client credentials flow.
                      options.AllowClientCredentialsFlow();

                      // Register the signing and encryption credentials.
                      options.AddDevelopmentEncryptionCertificate()
                                  .AddDevelopmentSigningCertificate();

                      // Register the ASP.NET Core host and configure the ASP.NET Core options.
                      options.UseAspNetCore()
                                  .EnableTokenEndpointPassthrough();
                  })

                  // Register the OpenIddict validation components.
                  .AddValidation(options =>
                  {
                      // Import the configuration from the local OpenIddict server instance.
                      options.UseLocalServer();

                      // Register the ASP.NET Core host.
                      options.UseAspNetCore();
                  });

                // Register the worker responsible of seeding the database with the sample clients.
                // Note: in a real world application, this step should be part of a setup script.
                services.AddHostedService<Worker>();
                services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>()?.HttpContext?.User ?? throw new Exception("User not defined."));
            }

         */
}