using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FitnessGym.Models;

namespace FitnessGym.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        virtual public DbSet<Programs> Programs { get; set; }
        virtual public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UsersRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UsersClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UsersTokens");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UsersLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        }
    }
}