using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;
using Clean.ProductionPlanner.Application.Responses;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Commands
{
    public class UpdateProjectTaskCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateProjectTaskDto ProjectTaskDto { get; set; }
    }
}