using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.ProductionPlanner.Persistence.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly ProductionPlannerDbContext _dbContext;

        public ProjectRepository(ProductionPlannerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
