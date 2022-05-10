using MediatR;

namespace Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Commands
{
    public class DeleteProjectTaskCommand : IRequest
    {
        public int Id { get; set; }
    }
}
