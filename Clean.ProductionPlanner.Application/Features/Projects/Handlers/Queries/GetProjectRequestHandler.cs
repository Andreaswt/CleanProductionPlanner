using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Queries;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Queries;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Projects.Handlers.Queries
{
    public class GetProjectRequestHandler : IRequestHandler<GetProjectRequest, ProjectDto>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectRequestHandler(IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        
        public async Task<ProjectDto> Handle(GetProjectRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProjectDto>(await _projectRepository.Get(request.Id));
        }
    }
}