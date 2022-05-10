using System.IO;
using Clean.ProductionPlanner.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Clean.ProductionPlanner.Identity
{
    public class ProductionPlannerIdentityDbContextFactory : IDesignTimeDbContextFactory<ProductionPlannerIdentityDbContext>
    {
        public ProductionPlannerIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ProductionPlannerIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("ProductionPlannerConnectionString");

            builder.UseSqlite(connectionString);

            return new ProductionPlannerIdentityDbContext(builder.Options);
        }
    }
}
