using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Clean.ProductionPlanner.Persistence
{
    public class ProductionPlannerDbContextFactory : IDesignTimeDbContextFactory<ProductionPlannerDbContext>
    {
        public ProductionPlannerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ProductionPlannerDbContext>();
            var connectionString = configuration.GetConnectionString("ProductionPlannerConnectionString");

            builder.UseSqlite(connectionString);

            return new ProductionPlannerDbContext(builder.Options);
        }
    }
}
