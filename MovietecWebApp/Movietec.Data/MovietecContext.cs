using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Movietec.Models.DbModels;

namespace Movietec.Data
{
    public class MovietecContext : IdentityDbContext<ApplicationUser>
    {
        public MovietecContext()
            : base("MovietecContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public static MovietecContext Create()
        {
            return new MovietecContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MovietecContext>(null);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins");
        }
    }
}
