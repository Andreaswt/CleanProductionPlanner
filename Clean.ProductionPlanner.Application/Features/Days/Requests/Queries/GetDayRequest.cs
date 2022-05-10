using Clean.ProductionPlanner.Application.DTOs.Day;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Days.Requests.Queries
{
    public class GetDayRequest : IRequest<DayDto>
    {
        public int Id { get; set; }
    }
}
