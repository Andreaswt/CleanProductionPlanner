using Clean.ProductionPlanner.Domain;
using Clean.ProductionPlanner.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clean.ProductionPlanner.Persistence
{
    public class ProductionPlannerDbContext : AuditableDbContext
    {
        public ProductionPlannerDbContext(DbContextOptions<ProductionPlannerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductionPlannerDbContext).Assembly);
            
            modelBuilder
                .Entity<ProjectTask>()
                .HasOne(e => e.Project)
                .WithMany(e => e.ProjectTasks)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
        
        public DbSet<Day> Days { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTask { get; set; }
    }
}
