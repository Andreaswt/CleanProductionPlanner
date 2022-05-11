using System;
using System.Collections.Generic;
using Clean.ProductionPlanner.Application.DTOs.Day;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Days.Requests.Queries
{
    public class GetDayListRequest : IRequest<List<DayDto>>
    {
        public DateTime? FromDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
