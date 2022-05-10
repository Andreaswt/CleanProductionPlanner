using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.Responses;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Projects.Requests.Commands
{
    public class CreateProjectCommand : IRequest<BaseCommandResponse>
    {
        public ProjectDto ProjectDto { get; set; }
    }
}