namespace Bistrotic.WorkItems.Server.Tests.Fixture
{
    using System;

    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Infrastructure.DevOps;

    using Microsoft.Extensions.Configuration;

    public class DevOpsServerFixture : IDisposable
    {
        private bool _disposedValue;
        private DevOpsServer? _server;
        private WorkItemModuleSettings? _settings;

        public DevOpsServer Server => _server ??= new DevOpsServer(
            Settings.AzureDevOpsServerUrl ?? string.Empty,
            Settings.PersonalAccessToken ?? string.Empty);

        private WorkItemModuleSettings Settings => _settings ??= GetSettings();

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing && _server != null)
                {
                    _server.Dispose();
                    _server = null;
                }

                _disposedValue = true;
            }
        }

        private static WorkItemModuleSettings GetSettings()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<DevOpsServerUnitTests>();

            return builder.Build().GetSection(nameof(WorkItemModuleSettings)).Get<WorkItemModuleSettings>();
        }
    }
}