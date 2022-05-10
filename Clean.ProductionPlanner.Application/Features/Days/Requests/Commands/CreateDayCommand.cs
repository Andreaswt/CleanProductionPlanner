using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.Responses;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Days.Requests.Commands
{
    public class CreateDayCommand : IRequest<BaseCommandResponse>
    {
        public DayDto DayDto { get; set; }
    }
}