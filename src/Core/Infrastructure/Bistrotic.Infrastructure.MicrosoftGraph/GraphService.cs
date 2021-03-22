namespace Bistrotic.Infrastructure.MicrosoftGraph
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Graph;

    public class GraphService
    {
        private GraphServiceClient? _graphClient;

        public GraphService(GraphAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        protected GraphAuthenticationService AuthenticationService { get; }
        protected GraphServiceClient GraphClient => _graphClient ??= InitializeGraphClient();

        public async Task<IEnumerable<string>> GetUserIds()
        {
            var users = await GraphClient
                .Users
                .Request()
                .GetAsync()
                .ConfigureAwait(false);
            List<string> ids = new(users.Select(p => p.UserPrincipalName));
            while (users.NextPageRequest != null)
            {
                users = await users
                    .NextPageRequest
                    .GetAsync()
                    .ConfigureAwait(false);
                ids.AddRange(users.Select(p => p.UserPrincipalName).ToArray());
            }
            return ids;
        }

        private GraphServiceClient InitializeGraphClient()
              => new(AuthenticationService.AuthenticationProvider);
    }
}