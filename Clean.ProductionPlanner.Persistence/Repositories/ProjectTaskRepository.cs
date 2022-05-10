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
    public class ProjectTaskRepository : GenericRepository<ProjectTask>, IProjectTaskRepository
    {
        private readonly ProductionPlannerDbContext _dbContext;

        public ProjectTaskRepository(ProductionPlannerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
