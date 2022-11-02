using BetaBoxChat.Core.Aggregates.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetaBoxChat.Infrastructure.Data
{
    public class BetaBoxChatContext : IdentityDbContext<User, Role, Guid>
    {
        public BetaBoxChatContext(DbContextOptions options) : base(options)
        {
        }
    }
}