using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Clean.ProductionPlanner.Domain;

namespace Clean.ProductionPlanner.Application.Contracts.Persistence
{
    public interface IDayRepository : IGenericRepository<Day>
    {
        public Task<List<Day>> GetBetweenDates(DateTime startDate, DateTime endDate);
    }
}
