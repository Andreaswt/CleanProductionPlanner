using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Queries;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Queries;
using Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Queries;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.ProjectTasks.Handlers.Queries
{
    public class GetProjectTaskRequestHandler : IRequestHandler<GetProjectTaskRequest, ProjectTaskDto>
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly IMapper _mapper;

        public GetProjectTaskRequestHandler(IProjectTaskRepository projectTaskRepository,
            IMapper mapper)
        {
            _projectTaskRepository = projectTaskRepository;
            _mapper = mapper;
        }
        
        public async Task<ProjectTaskDto> Handle(GetProjectTaskRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProjectTaskDto>(await _projectTaskRepository.Get(request.Id));
        }
    }
}