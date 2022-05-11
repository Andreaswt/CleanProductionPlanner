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
    public class DayRepository : GenericRepository<Day>, IDayRepository
    {
        private readonly ProductionPlannerDbContext _dbContext;

        public DayRepository(ProductionPlannerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<Day>> GetBetweenDates(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null && endDate == null)
                return await _dbContext.Days.ToListAsync();
            
            if (startDate == null && endDate != null)
                return await _dbContext.Days.Where(x => x.Date <= endDate).ToListAsync();
            
            if (startDate != null && endDate == null)
                return await _dbContext.Days.Where(x => x.Date >= startDate).ToListAsync();
            
            return await _dbContext.Days.Where(x => x.Date >= startDate && x.Date <= endDate).ToListAsync();
        }
    }
}
