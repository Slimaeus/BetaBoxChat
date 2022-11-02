using BetaBoxChat.Core.Aggregates.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetaBoxChat.Infrastructure.Data
{
    public class BetaBoxChatContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public BetaBoxChatContext(DbContextOptions options) : base(options)
        {
        }
    }
}