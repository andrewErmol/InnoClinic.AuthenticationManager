using AuthenticationManager.DAL.Configurations;
using AuthenticationManager.DAL.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationManager.DAL
{
    public class AuthenticationManagerDbContext : IdentityDbContext<Account>
    {
        public AuthenticationManagerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
