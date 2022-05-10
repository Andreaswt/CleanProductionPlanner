using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Days.Requests.Commands
{
    public class DeleteDayCommand : IRequest
    {
        public int Id { get; set; }
    }
}
