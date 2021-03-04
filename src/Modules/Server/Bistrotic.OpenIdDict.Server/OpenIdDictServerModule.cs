namespace Bistrotic.OpenIdDict
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography.X509Certificates;

    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.OpenIdDict.Application.Queries;
    using Bistrotic.OpenIdDict.Data;
    using Bistrotic.OpenIdDict.Models;
    using Bistrotic.OpenIdDict.Settings;
    using Bistrotic.OpenIdDict.Workers;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

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
            services.Configure<OpenIdSettings>(Configuration.GetSection(nameof(OpenIdSettings)));

            services.AddDbContext<SecurityDbContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(Configuration.GetConnectionString(nameof(OpenIdDict)),
                    x => x.MigrationsAssembly(typeof(SecurityDbContext).Assembly.GetName().Name));

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
                            .RequireProofKeyForCodeExchange()
                            .AllowRefreshTokenFlow();
                    AddCertificates(options);
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
            // Register the worker responsible of seeding the database with the sample clients if in
            // development environment.
            services.AddHostedService<OpenIdDevelopmentWorker>();
        }

        private static X509Certificate2? GetCertificate(StoreName storeName, StoreLocation storeLocation, string thumbprint)
        {
            try
            {
                var store = new X509Store(storeName, storeLocation);
                store.Open(OpenFlags.ReadOnly);
                var cert = store
                    .Certificates
                    .Find(X509FindType.FindByThumbprint, thumbprint, false)
                    .OfType<X509Certificate2>()
                    .SingleOrDefault();
                if (cert != null)
                {
                    Console.WriteLine($"Loaded certificate : {storeLocation}/{storeName}/{thumbprint}.");
                }
                return cert;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading certificate '{thumbprint}' in store Name='{storeName}', Location='{storeLocation}'.\n{e.Message}");
            }
            return null;
        }

        private static X509Certificate2? GetFileCertificate(IEnumerable<string> paths, string fileName)
        {
            foreach (var path in paths)
            {
                string filePath = Path.Combine(path, fileName);
                if (File.Exists(filePath))
                {
                    var cert = (X509Certificate2)X509Certificate.CreateFromCertFile(filePath);
                    Console.WriteLine($"Loaded certificate : {filePath}.");
                    return cert;
                }
            }
            return null;
        }

        private void AddCertificates(OpenIddictServerBuilder options)
        {
            string thumbprint = Configuration.GetSection(nameof(OpenIdSettings)).GetValue<string>(nameof(OpenIdSettings.EncryptionCertificateThumbprint));
            string fileName = Configuration.GetSection(nameof(OpenIdSettings)).GetValue<string>(nameof(OpenIdSettings.EncryptionCertificateFile));
            if (string.IsNullOrWhiteSpace(thumbprint) && string.IsNullOrWhiteSpace(fileName))
            {
                if (Environment.IsDevelopment())
                {
                    Console.WriteLine("Using auto generated development encryption certificate");
                    options.AddDevelopmentEncryptionCertificate();
                }
                else
                {
                    throw new NotSupportedException($"Auto generated encryption certificate can only be used in development environments. Set a certificate using {nameof(OpenIdSettings)}:{nameof(OpenIdSettings.EncryptionCertificateThumbprint)} or {nameof(OpenIdSettings)}:{nameof(OpenIdSettings.EncryptionCertificateFile)} settings.");
                }
            }
            else
            {
                Console.WriteLine($"Encryption certificate : Thumbprint='{thumbprint}', FileName='{fileName}'.");
                options.AddEncryptionCertificate(GetCertificate(thumbprint, fileName));
            }
            thumbprint = Configuration.GetSection(nameof(OpenIdSettings)).GetValue<string>(nameof(OpenIdSettings.SigningCertificateThumbprint));
            fileName = Configuration.GetSection(nameof(OpenIdSettings)).GetValue<string>(nameof(OpenIdSettings.SigningCertificateFile));
            if (string.IsNullOrWhiteSpace(thumbprint) && string.IsNullOrWhiteSpace(fileName))
            {
                if (Environment.IsDevelopment())
                {
                    Console.WriteLine("Using auto generated development signing certificate");
                    options.AddDevelopmentSigningCertificate();
                }
                else
                {
                    throw new NotSupportedException($"Auto generated signing certificate can only be used in development environments. Set a certificate using {nameof(OpenIdSettings)}:{nameof(OpenIdSettings.SigningCertificateThumbprint)} or {nameof(OpenIdSettings)}:{nameof(OpenIdSettings.SigningCertificateFile)} settings.");
                }
            }
            else
            {
                Console.WriteLine($"Signing certificate : Thumbprint='{thumbprint}', FileName='{fileName}'.");
                options.AddSigningCertificate(GetCertificate(thumbprint, fileName));
            }
        }

        private X509Certificate2 GetCertificate(string thumbprint, string fileName)
        {
            X509Certificate2? cert = null;
            if (thumbprint != null)
            {
                cert =
                    GetCertificate(StoreName.CertificateAuthority, StoreLocation.LocalMachine, thumbprint) ??
                    GetCertificate(StoreName.CertificateAuthority, StoreLocation.CurrentUser, thumbprint) ??
                    GetCertificate(StoreName.Root, StoreLocation.LocalMachine, thumbprint) ??
                    GetCertificate(StoreName.Root, StoreLocation.CurrentUser, thumbprint) ??
                    GetCertificate(StoreName.My, StoreLocation.CurrentUser, thumbprint);
                if (cert == null && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    cert = GetCertificate(StoreName.My, StoreLocation.LocalMachine, thumbprint);
                }
            }
            if (cert == null && !string.IsNullOrWhiteSpace(fileName))
            {
                var directories = new List<string>();
                Configuration.GetSection(nameof(OpenIdSettings)).Bind(nameof(OpenIdSettings.CertificatePaths), directories);
                directories.Add(AppDomain.CurrentDomain.BaseDirectory);
                cert = GetFileCertificate(directories, fileName);
                return cert ?? throw new Exception($"The certificate file '{fileName}' could not be found in directories : {string.Join("; ", directories)}");
            }
            return cert ?? throw new Exception($"The certificate with thumbprint '{thumbprint}' could not be found.");
        }
    }
}