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
    public class ProjectService : BaseHttpService, IProjectService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public ProjectService(IMapper mapper, IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }
        
        public async Task<ProjectVM> GetProject(int id)
        {
            AddBearerToken();
            var project = await _client.ProjectsGETAsync(id);
            return _mapper.Map<ProjectVM>(project);
        }

        public async Task<List<ProjectVM>> GetProjects()
        {
            AddBearerToken();
            var projects = await _client.ProjectsAllAsync();
            return _mapper.Map<List<ProjectVM>>(projects);
        }
        
        public async Task<Response<int>> CreateProject(CreateProjectVM project)
        {
            try
            {
                var response = new Response<int>();
                CreateProjectDto createProject = _mapper.Map<CreateProjectDto>(project);
                AddBearerToken();
                var apiResponse = await _client.ProjectsPOSTAsync(createProject);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> UpdateProject(UpdateProjectVM project)
        {
            try
            {
                UpdateProjectDto updateProject = _mapper.Map<UpdateProjectDto>(project);
                AddBearerToken();
                await _client.ProjectsPUTAsync(updateProject);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
        
        public async Task<Response<int>> DeleteProject(int id)
        {
            try
            {
                AddBearerToken();
                await _client.ProjectsDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
