using AutoMapper;
using Clean.ProductionPlanner.MVC.Contracts;
using Clean.ProductionPlanner.MVC.Models;
using Clean.ProductionPlanner.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.ProductionPlanner.MVC.Contracts;
using Clean.ProductionPlanner.MVC.Services.Base;

namespace Clean.ProductionPlanner.MVC.Services
{
    public class ProjectTaskService : BaseHttpService, IProjectTaskService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public ProjectTaskService(IMapper mapper, IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }
        
        public async Task<ProjectTaskVM> GetProjectTask(int id)
        {
            AddBearerToken();
            var projectTask = await _client.ProjectsGETAsync(id);
            return _mapper.Map<ProjectTaskVM>(projectTask);
        }

        public async Task<Response<int>> UpdateProjectTask(UpdateProjectTaskVM projectTask, int id)
        {
            try
            {
                UpdateProjectTaskDto updateProjectTask = _mapper.Map<UpdateProjectTaskDto>(projectTask);
                AddBearerToken();
                await _client.ProjectTasksPUTAsync(id, updateProjectTask);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
        
        public async Task<Response<int>> DeleteProjectTask(int id)
        {
            try
            {
                AddBearerToken();
                await _client.ProjectTasksDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
