using Clean.ProductionPlanner.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clean.ProductionPlanner.Identity.Configurations;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Clean.ProductionPlanner.Identity.Configurations;
using Clean.ProductionPlanner.Identity.Models;

namespace Clean.ProductionPlanner.Identity
{
    public class ProductionPlannerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProductionPlannerIdentityDbContext(DbContextOptions<ProductionPlannerIdentityDbContext> options)
            : base(options)
        {
        }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
        //     {
        //         options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        //     });
        //     base.OnConfiguring(optionsBuilder);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
