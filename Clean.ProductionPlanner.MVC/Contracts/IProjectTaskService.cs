using Clean.ProductionPlanner.MVC.Models;
using Clean.ProductionPlanner.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.ProductionPlanner.MVC.Contracts
{
    public interface IProjectTaskService
    {
        public Task<ProjectTaskVM> GetProjectTask(int id);
        public Task<Response<int>> UpdateProjectTask(UpdateProjectTaskVM project, int id);
        public Task<Response<int>> DeleteProjectTask(int id);
    }
}
