using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Projects.Requests.Commands
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
