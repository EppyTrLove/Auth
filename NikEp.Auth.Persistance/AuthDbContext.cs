using Microsoft.EntityFrameworkCore;
using NikEp.Auth.Domain.Entities;

namespace NikEp.Auth.Persistance
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
