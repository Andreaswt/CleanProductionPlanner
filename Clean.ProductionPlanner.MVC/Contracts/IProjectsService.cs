using Clean.ProductionPlanner.MVC.Models;
using Clean.ProductionPlanner.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.ProductionPlanner.MVC.Contracts
{
    public interface IProjectService
    {
        public Task<ProjectVM> GetProject(int id);
        public Task<List<ProjectVM>> GetProjects();
        public Task<Response<int>> CreateProject(CreateProjectVM project);
        public Task<Response<int>> UpdateProject(UpdateProjectVM project);
        public Task<Response<int>> DeleteProject(int id);
    }
}
