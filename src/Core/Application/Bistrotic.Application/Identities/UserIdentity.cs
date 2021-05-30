namespace Bistrotic.Application.Identities
{
    using System.Security.Principal;

    using Bistrotic.Application.Services;

    public class UserIdentity : IUserIdentity
    {
        private readonly IPrincipal _identity;

        public UserIdentity(IPrincipal identity)
        {
            _identity = identity;
        }

        public string? UserName => _identity.Identity?.Name;
    }
}