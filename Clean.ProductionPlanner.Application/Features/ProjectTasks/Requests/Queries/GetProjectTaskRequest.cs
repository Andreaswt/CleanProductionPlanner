using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Queries
{
    public class GetProjectTaskRequest : IRequest<ProjectTaskDto>
    {
        public int Id { get; set; }
    }
}
