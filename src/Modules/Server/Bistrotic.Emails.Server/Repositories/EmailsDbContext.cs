namespace Bistrotic.Emails.Repositories
{
    using Bistrotic.Emails.Domain.States;
    using Bistrotic.Infrastructure.EfCore.Repositories;

    using Microsoft.EntityFrameworkCore;

    public sealed class EmailsDbContext : StateStoreDbContext<IEmailState, EmailEfState>
    {
        public EmailsDbContext(DbContextOptions<EmailsDbContext> options) : base(options)
        {
        }
    }
}