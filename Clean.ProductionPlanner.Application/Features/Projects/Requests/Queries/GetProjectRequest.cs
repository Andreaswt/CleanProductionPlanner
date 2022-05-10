using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Projects.Requests.Queries
{
    public class GetProjectRequest : IRequest<ProjectDto>
    {
        public int Id { get; set; }
    }
}
