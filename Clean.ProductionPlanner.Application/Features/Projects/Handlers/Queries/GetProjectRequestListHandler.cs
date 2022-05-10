using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Queries;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Queries;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Projects.Handlers.Queries
{
    public class GetProjectListRequestHandler : IRequestHandler<GetProjectListRequest
        , List<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectListRequestHandler(IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        
        public async Task<List<ProjectDto>> Handle(GetProjectListRequest request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAll();
            return _mapper.Map<List<ProjectDto>>(projects);
        }
    }
}