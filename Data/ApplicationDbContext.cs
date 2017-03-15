using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExtendIdentityUserRole.Models;

namespace ExtendIdentityUserRole.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Ignore<IdentityUserRole<string>>();

            builder.Entity<CustomUserRole>().HasIndex(r => r.CustomProperty);
            builder.Entity<CustomUserRole>().HasKey(r => new { r.UserId, r.RoleId, r.CompanyId });
        }
    }
}
