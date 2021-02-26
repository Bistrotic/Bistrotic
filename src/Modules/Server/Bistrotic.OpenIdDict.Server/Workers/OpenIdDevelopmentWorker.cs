using System;
using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Infrastructure;
using Bistrotic.OpenIdDict.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using OpenIddict.Abstractions;

using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Bistrotic.OpenIdDict.Workers
{
    public class OpenIdDevelopmentWorker : IHostedService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IServiceProvider _serviceProvider;

        public OpenIdDevelopmentWorker(IServiceProvider serviceProvider, IWebHostEnvironment environment)
        {
            _serviceProvider = serviceProvider;
            _environment = environment;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (!_environment.IsDevelopment())
                return;
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<SecurityDbContext>();
            await context.Database.EnsureCreatedAsync(cancellationToken);
            var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

            if (await manager.FindByClientIdAsync(BistroticConstants.ServerApiName, cancellationToken) is null)
            {
#pragma warning disable S1075 // URIs should not be hardcoded
                const string debugUrl = "https://localhost:5001/authentication/";
#pragma warning restore S1075 // URIs should not be hardcoded
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = BistroticConstants.ServerApiName,
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

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}