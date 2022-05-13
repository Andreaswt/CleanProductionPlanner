using Clean.ProductionPlanner.MVC.Models;
using Clean.ProductionPlanner.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.ProductionPlanner.MVC.Contracts
{
    public interface IDayService
    {
        public Task<DayVM> GetDay(int id);
        public Task<List<DayVM>> GetDays();
    }
}
