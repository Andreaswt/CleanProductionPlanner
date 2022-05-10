using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;
using Clean.ProductionPlanner.Application.Responses;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Commands
{
    public class CreateProjectTaskCommand : IRequest<BaseCommandResponse>
    {
        public int ProjectId { get; set; }
        public ProjectTaskDto ProjectTaskDto { get; set; }
    }
}