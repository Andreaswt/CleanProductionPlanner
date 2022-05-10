using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.Responses;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Days.Requests.Commands
{
    public class UpdateDayCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DayDto DayDto { get; set; }
    }
}